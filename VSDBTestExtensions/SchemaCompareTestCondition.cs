using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;

namespace VSDBTestExtensions
{
    [ExportTestCondition("VSDB - Result Set Schema Compare", typeof(SchemaCompareTestCondition))]
    public class SchemaCompareTestCondition : TestCondition
    {
        private bool _isCaseSensitive;
        private string _resultSetString;
        private bool _isLooseComparison;

        public SchemaCompareTestCondition()
        {
            _resultSetString = "ALL";
            _isCaseSensitive = false;
            _isLooseComparison = false;
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

            //validate ResultSetList does not include result sets that do not exist
            foreach (var rs in resultSetList.Where(rs => rs > result.DataSet.Tables.Count))
                throw new ArgumentException(String.Format("Result Set {0} does not exist", rs));

            var currentResultSetId = resultSetList[0];
            var currentColumnSet = result.DataSet.Tables[currentResultSetId - 1].Columns;
            resultSetList.RemoveAt(0);

            foreach (var rs in resultSetList)
            {
                var comparisonTable = result.DataSet.Tables[rs - 1];

                //verify that the same number of columns is the same for as recorded
                if (comparisonTable.Columns.Count != currentColumnSet.Count)
                {
                    throw new Exception
                        (
                            String.Format
                            (
                                "Result Set {0}: {1} columns in does not match the {2} columns in Result Set {3}",
                                rs,
                                comparisonTable.Columns.Count,
                                currentColumnSet.Count,
                                currentResultSetId
                            )
                        );
                }

                //loop through columns and verify the base data type of the columns
                for (var c = 0; c < currentColumnSet.Count; c++)
                {
                    if (String.Compare(currentColumnSet[c].ColumnName, comparisonTable.Columns[c].ColumnName, !IsCaseSensitive) != 0)
                    {
                        throw new Exception
                            (
                                String.Format
                                (
                                    "Result Set {0}: Column {1} ({2}) does not match name for column in Result Set {3} ({4})",
                                    rs,
                                    c + 1,
                                    comparisonTable.Columns[c].ColumnName,
                                    currentResultSetId,
                                    currentColumnSet[c].ColumnName
                                )
                            );
                    }

                    //compare datatypes
                    if (IsLooseComparison)
                    {
                        var currentType = GetLooseType(currentColumnSet[c].DataType.Name);
                        var comparisonType = GetLooseType(comparisonTable.Columns[c].DataType.Name);

                        if (currentType != comparisonType)
                        {
                            throw new Exception
                                (
                                    String.Format
                                    (
                                        "Result Set {0} Column {1} ({2}) does not match type for column in Result Set {3} ({4})",
                                        rs,
                                        c + 1,
                                        comparisonTable.Columns[c].DataType,
                                        currentResultSetId,
                                        currentColumnSet[c].DataType
                                    )
                                );
                        }
                    }
                    else
                    {
                        if (String.Compare(currentColumnSet[c].DataType.ToString(), comparisonTable.Columns[c].DataType.ToString(), !IsCaseSensitive) != 0)
                        {
                            throw new Exception
                                (
                                    String.Format
                                    (
                                        "Result Set {0} Column {1} ({2}) does not match type for column in Result Set {3} ({4})",
                                        rs,
                                        c + 1,
                                        comparisonTable.Columns[c].DataType,
                                        currentResultSetId,
                                        currentColumnSet[c].DataType
                                    )
                                );
                        }
                    }
                }
            }
        }

        private string GetLooseType(string dataTypeName)
        {
            if ("Byte,Int16,Int32,Int64,SByte,UInt16,UInt32,UInt64,".Contains(dataTypeName + ","))
            {
                return "Integer";
            }
            return "Decimal,Double,Single,".Contains(dataTypeName + ",") ? "Decimal" : dataTypeName;
        }

        public override string ToString()
        {
            return String.Format("Condition fails if Result Sets ({0}) do not have the same schema (IsCaseSensitive = {1})", ResultSets, IsCaseSensitive);
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
        [Description("Whether or not column name comparison is case-sensitive")]
        public bool IsCaseSensitive
        {
            get { return _isCaseSensitive; }

            set
            {
                _isCaseSensitive = value;
            }
        }

        [Category("Test Condition")]
        [DisplayName("Loose Comparison")]
        [Description("If TRUE, all integer types equate, all decimal types equate, and all string types equate.  If FALSE, compare actual data types.")]
        public bool IsLooseComparison
        {
            get { return _isLooseComparison; }

            set
            {
                _isLooseComparison = value;
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
