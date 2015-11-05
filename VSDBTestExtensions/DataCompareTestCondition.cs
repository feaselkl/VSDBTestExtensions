using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;

namespace VSDBTestExtensions
{
    [ExportTestCondition("VSDB - Result Set Data Compare", typeof(DataCompareTestCondition))]
    public class DataCompareTestCondition : TestCondition
    {

        private string _resultSetString;
        private bool _isCaseSensitive;
        private bool _enforceOrder;

        public DataCompareTestCondition()
        {
            _resultSetString = "ALL";
            _isCaseSensitive = false;
            _enforceOrder = false;
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
                    resultSetList.AddRange(ResultSets.Split(',').Select(rs => Convert.ToInt16(rs)).Select(dummy => (int)dummy));
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
                throw new ArgumentException(String.Format("ResultSet {0} does not exist", rs));

            var currentResultSetId = resultSetList[0];
            var firstTable = result.DataSet.Tables[currentResultSetId - 1];
            resultSetList.RemoveAt(0);

            //loop through batches verifying that the column count for each batch is the same
            foreach (var rs in resultSetList)
            {
                //verify resultset exists
                if (result.DataSet.Tables.Count < rs)
                {
                    throw new Exception(String.Format("ResultSet {0} does not exist", rs));
                }

                var secondTable = result.DataSet.Tables[rs - 1];

                //verify that the same number of columns is the same for as recorded
                if (firstTable.Columns.Count != secondTable.Columns.Count)
                {
                    throw new Exception
                        (
                            String.Format
                            (
                                "Result Set {0}: {1} columns in does not match the {2} columns in Result Set {3}",
                                currentResultSetId,
                                firstTable.Columns.Count,
                                secondTable.Columns.Count,
                                rs
                            )
                        );
                }

                //verify that the number of rows is the same for as recorded
                if (firstTable.Rows.Count != secondTable.Rows.Count)
                {
                    throw new Exception
                        (
                            String.Format
                            (
                                "Result Set {0}: {1} rows does not match the {2} rows in Result Set {3}",
                                currentResultSetId,
                                firstTable.Rows.Count,
                                secondTable.Rows.Count,
                                rs
                            )
                        );
                }

                var differenceTable = DataSetComparison.CompareDataTables(firstTable, secondTable, IsCaseSensitive, EnforceOrder);

                if (differenceTable.Rows.Count != 0)
                {
                    throw new Exception
                        (
                            String.Format
                            (
                                "Result Set {0} and Result Set {2} had {1} mismatched records total",
                                currentResultSetId,
                                differenceTable.Rows.Count,
                                rs
                            )
                        );
                }
            }
        }

        public override string ToString()
        {
            return String.Format("Condition fails if Result Sets ({0}) do not have the same data", ResultSets);
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

        [Category("Test Condition")]
        [DisplayName("Case Sensitive")]
        [Description("Whether or not the data comparison is case-sensitive")]
        public bool IsCaseSensitive
        {
            get { return _isCaseSensitive; }

            set
            {
                _isCaseSensitive = value;
            }
        }

        [Category("Test Condition")]
        [DisplayName("Order Sensitive")]
        [Description("Whether or not the data comparison is order-sensitive.  If this is set to FALSE, comparisons are set-based meaning true duplicate rows get 'smashed' together.  Combine this with a VSDB Row Count condition in that case.")]
        public bool EnforceOrder
        {
            get { return _enforceOrder; }

            set
            {
                _enforceOrder = value;
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

