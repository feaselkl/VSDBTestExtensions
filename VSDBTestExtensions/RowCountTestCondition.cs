using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;

namespace VSDBTestExtensions
{
    [ExportTestCondition("VSDB - Result Set Row Count Match", typeof(RowCountTestCondition))]
    public class RowCountTestCondition : TestCondition
    {
        private string _resultSetString;

        public RowCountTestCondition()
        {
            _resultSetString = "ALL";
        }

        public override void Assert(DbConnection validationConnection, SqlExecutionResult[] results)
        {
            base.Assert(validationConnection, results);

            var result = results[0];
            var resultSetList = new List<int>();

            try
            {
                if (ResultSets.ToUpper() == "ALL")
                {
                    resultSetList.AddRange(Enumerable.Range(1, result.DataSet.Tables.Count));
                }
                else if (ResultSets.Contains(","))
                {
                    resultSetList.AddRange(ResultSets.Split(',').Select(rs => Convert.ToInt16(rs)).Select(dummy => (int) dummy));
                }
                else if (ResultSets.Contains(":"))
                {
                    var temp = ResultSets.Split(':');
                    resultSetList.AddRange(Enumerable.Range(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1])));
                }
                else
                {
                    throw new ArgumentException("Invalid specification for result sets");
                }
            }
            catch
            {
                throw new ArgumentException(String.Format("{0} is an invalid result set specification.", ResultSets));
            }

            foreach (var rs in resultSetList.Where(rs => rs > result.DataSet.Tables.Count))
                throw new ArgumentException(String.Format("Result Set {0} does not exist", rs));

            var currentResultSetId = resultSetList[0];
            var table = result.DataSet.Tables[currentResultSetId - 1];
            var numberOfRows = table.Rows.Count;
            resultSetList.RemoveAt(0);

            //loop through batches verifying that the column count for each batch is the same
            foreach (var rs in resultSetList)
            {
                //verify resultset exists
                if (result.DataSet.Tables.Count < rs)
                {
                    throw new Exception(String.Format("Result Set {0} does not exist", rs));
                }

                //actual condition verification
                //verify resultset row count matches expected
                table = result.DataSet.Tables[rs - 1];

                if (table.Rows.Count != numberOfRows)
                    throw new Exception
                    (
                        String.Format
                        (
                            "Result Set {0}: {1} rows does not match the {2} rows in Result Set {3}",
                            rs,
                            table.Rows.Count,
                            numberOfRows,
                            currentResultSetId
                        )
                    );
            }
        }

        public override string ToString()
        {
            return String.Format("Condition fails if Result Sets ({0}) does not contain the same number of rows", ResultSets);
        }

        #region Properties
        [Category("Test Condition")]
        [DisplayName("Result Sets")]
        [Description("Which result sets you want to compare - ALL, a sequence (2:5) or comma-separated list (1,3,5).  Result set numbering starts at 1.")]
        public string ResultSets
        {
            get { return _resultSetString; }

            set
            {
                if (!IsValidResultSetString(value))
                {
                    throw new ArgumentException("Valid specifications include:  ALL, sequences (e.g., 4:7), comma-separated list (2,4,6)");
                }
                _resultSetString = value;

            }
        }

        private static bool IsValidResultSetString(string resultSetString)
        {
            return
                (
                    resultSetString.ToUpper() == "ALL"
                    || resultSetString.Contains(":")
                    || resultSetString.Contains(",")
                );
        }
        #endregion
    }
}
