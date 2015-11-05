using System.Collections;
using System.Data;
using System.Linq;

namespace VSDBTestExtensions
{
    public class DataSetComparison
    {
        public static DataTable CompareDataTables(DataTable firstDataTable, DataTable secondDataTable, bool isCaseSensitive = false, bool enforceOrder = false)
        {
            firstDataTable.CaseSensitive = isCaseSensitive;
            secondDataTable.CaseSensitive = isCaseSensitive;

            if (enforceOrder)
            {
                firstDataTable.Columns.Add(new DataColumn("CSTestSortOrder", typeof (int)));
                secondDataTable.Columns.Add(new DataColumn("CSTestSortOrder", typeof(int)));

                for (var i = 0; i < firstDataTable.Rows.Count; i++)
                {
                    firstDataTable.Rows[i]["CSTestSortOrder"] = i;
                }
                for (var i = 0; i < secondDataTable.Rows.Count; i++)
                {
                    secondDataTable.Rows[i]["CSTestSortOrder"] = i;
                }
            }

            var differences = firstDataTable.AsEnumerable().Except(secondDataTable.AsEnumerable(), DataRowComparer.Default)
                                .Union(secondDataTable.AsEnumerable().Except(firstDataTable.AsEnumerable(), DataRowComparer.Default));

            var resultDataTable = differences.Any() ? differences.CopyToDataTable() : new DataTable();
            resultDataTable.TableName = "ResultDataTable";

            return resultDataTable;
        }
    }
}
