using System;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VSDBTestExtensions;

namespace VSDBTestExtensions.UnitTests
{
    [TestClass]
    public class DataSetComparisonTests
    {
        private DataTable dt1 = null;
        private DataTable dt2 = null;
        private DataTable dt3 = null;
        private DataTable dt4 = null;
        private DataTable dt5 = null;
        private DataTable empty = null;
        private DataTable different = null;
        private DataTable extralong1 = null;
        private DataTable extralong2 = null;

        [TestInitialize]
        public void Initialize()
        {
            #region Table Setup

            dt1 = new DataTable("Table1");
            dt1.Columns.Add(new DataColumn("c1", typeof(int)));
            dt1.Columns.Add(new DataColumn("c2", typeof(int)));
            dt1.Columns.Add(new DataColumn("c3", typeof(int)));

            var r1 = dt1.NewRow();
            r1["c1"] = 1;
            r1["c2"] = 1;
            r1["c3"] = 1;
            dt1.Rows.Add(r1);

            var r2 = dt1.NewRow();
            r2["c1"] = 2;
            r2["c2"] = 3;
            r2["c3"] = 4;
            dt1.Rows.Add(r2);

            dt2 = new DataTable("Table2");
            dt2.Columns.Add(new DataColumn("c1", typeof(int)));
            dt2.Columns.Add(new DataColumn("c2", typeof(int)));
            dt2.Columns.Add(new DataColumn("c3", typeof(int)));

            var r11 = dt2.NewRow();
            r11["c1"] = 1;
            r11["c2"] = 1;
            r11["c3"] = 1;
            dt2.Rows.Add(r11);

            var r22 = dt2.NewRow();
            r22["c1"] = 2;
            r22["c2"] = 3;
            r22["c3"] = 4;
            dt2.Rows.Add(r22);

            dt3 = new DataTable("Table3");
            dt3.Columns.Add(new DataColumn("c1", typeof(int)));
            dt3.Columns.Add(new DataColumn("c2", typeof(int)));
            dt3.Columns.Add(new DataColumn("c3", typeof(int)));

            var r13 = dt3.NewRow();
            r13["c1"] = 9;
            r13["c2"] = 9;
            r13["c3"] = 9;
            dt3.Rows.Add(r13);

            var r23 = dt3.NewRow();
            r23["c1"] = 7;
            r23["c2"] = 6;
            r23["c3"] = 5;
            dt3.Rows.Add(r23);

            dt4 = new DataTable("Table4");
            dt4.Columns.Add(new DataColumn("c1", typeof(int)));
            dt4.Columns.Add(new DataColumn("c2", typeof(int)));
            dt4.Columns.Add(new DataColumn("c3", typeof(int)));

            var r42 = dt4.NewRow();
            r42["c1"] = 2;
            r42["c2"] = 3;
            r42["c3"] = 4;
            dt4.Rows.Add(r42);

            var r4 = dt4.NewRow();
            r4["c1"] = 1;
            r4["c2"] = 1;
            r4["c3"] = 1;
            dt4.Rows.Add(r4);

            dt5 = new DataTable("Table4");
            dt5.Columns.Add(new DataColumn("c1", typeof(int)));
            dt5.Columns.Add(new DataColumn("c2", typeof(int)));
            dt5.Columns.Add(new DataColumn("c3", typeof(int)));

            var r5 = dt5.NewRow();
            r5["c1"] = 1;
            r5["c2"] = 1;
            r5["c3"] = 1;
            dt5.Rows.Add(r5);

            var r52 = dt5.NewRow();
            r52["c1"] = 2;
            r52["c2"] = 3;
            r52["c3"] = 4;
            dt5.Rows.Add(r52);

            var r53 = dt5.NewRow();
            r53["c1"] = 2;
            r53["c2"] = 3;
            r53["c3"] = 4;
            dt5.Rows.Add(r53);

            empty = new DataTable("Empty");
            empty.Columns.Add(new DataColumn("c1", typeof(int)));
            empty.Columns.Add(new DataColumn("c2", typeof(int)));
            empty.Columns.Add(new DataColumn("c3", typeof(int)));


            different = new DataTable("Different");
            different.Columns.Add(new DataColumn("cx", typeof(string)));
            different.Columns.Add(new DataColumn("c2", typeof(string)));

            var rd = different.NewRow();
            rd["cx"] = "CX";
            rd["c2"] = "C2";
            different.Rows.Add(rd);

            extralong1 = new DataTable("ExtraLong1");
            extralong1.Columns.Add(new DataColumn("c1", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c2", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c3", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c4", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c5", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c6", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c7", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c8", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c9", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c10", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c11", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c12", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c13", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c14", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c15", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c16", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c17", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c18", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c19", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c20", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c21", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c22", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c23", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c24", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c25", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c26", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c27", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c28", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c29", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c30", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c31", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c32", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c33", typeof(int)));
            extralong1.Columns.Add(new DataColumn("c34", typeof(int)));

            var rxl1 = extralong1.NewRow();
            rxl1["c1"] = 1;
            rxl1["c2"] = 1;
            rxl1["c3"] = 1;
            rxl1["c4"] = 1;
            rxl1["c5"] = 1;
            rxl1["c6"] = 1;
            rxl1["c7"] = 1;
            rxl1["c8"] = 1;
            rxl1["c9"] = 1;
            rxl1["c10"] = 1;
            rxl1["c11"] = 1;
            rxl1["c12"] = 1;
            rxl1["c13"] = 1;
            rxl1["c14"] = 1;
            rxl1["c15"] = 1;
            rxl1["c16"] = 1;
            rxl1["c17"] = 1;
            rxl1["c18"] = 1;
            rxl1["c19"] = 1;
            rxl1["c20"] = 1;
            rxl1["c21"] = 1;
            rxl1["c22"] = 1;
            rxl1["c23"] = 1;
            rxl1["c24"] = 1;
            rxl1["c25"] = 1;
            rxl1["c26"] = 1;
            rxl1["c27"] = 1;
            rxl1["c28"] = 1;
            rxl1["c29"] = 1;
            rxl1["c30"] = 1;
            rxl1["c31"] = 1;
            rxl1["c32"] = 1;
            rxl1["c33"] = 1;
            rxl1["c34"] = 1;
            extralong1.Rows.Add(rxl1);

            extralong2 = new DataTable("ExtraLong2");
            extralong2.Columns.Add(new DataColumn("c1", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c2", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c3", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c4", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c5", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c6", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c7", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c8", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c9", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c10", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c11", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c12", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c13", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c14", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c15", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c16", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c17", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c18", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c19", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c20", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c21", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c22", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c23", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c24", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c25", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c26", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c27", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c28", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c29", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c30", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c31", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c32", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c33", typeof(int)));
            extralong2.Columns.Add(new DataColumn("c34", typeof(int)));

            var rxl2 = extralong2.NewRow();
            rxl2["c1"] = 1;
            rxl2["c2"] = 1;
            rxl2["c3"] = 1;
            rxl2["c4"] = 1;
            rxl2["c5"] = 1;
            rxl2["c6"] = 1;
            rxl2["c7"] = 1;
            rxl2["c8"] = 1;
            rxl2["c9"] = 1;
            rxl2["c10"] = 1;
            rxl2["c11"] = 1;
            rxl2["c12"] = 1;
            rxl2["c13"] = 1;
            rxl2["c14"] = 1;
            rxl2["c15"] = 1;
            rxl2["c16"] = 1;
            rxl2["c17"] = 1;
            rxl2["c18"] = 1;
            rxl2["c19"] = 1;
            rxl2["c20"] = 1;
            rxl2["c21"] = 1;
            rxl2["c22"] = 1;
            rxl2["c23"] = 1;
            rxl2["c24"] = 1;
            rxl2["c25"] = 1;
            rxl2["c26"] = 1;
            rxl2["c27"] = 1;
            rxl2["c28"] = 1;
            rxl2["c29"] = 1;
            rxl2["c30"] = 1;
            rxl2["c31"] = 1;
            rxl2["c32"] = 1;
            rxl2["c33"] = 1;
            rxl2["c34"] = 1;
            extralong2.Rows.Add(rxl2);

            #endregion
        }

        [TestMethod]
        public void DataSetComparison_EqualDataTables_ComparisonReturnsNoResults()
        {
            var dt = DataSetComparison.CompareDataTables(dt1, dt2, true);
            Assert.AreEqual(0, dt.Rows.Count);
        }

        [TestMethod]
        public void DataSetComparison_EqualDataTables_WrongOrder_ComparisonReturnsNoResults()
        {
            var dt = DataSetComparison.CompareDataTables(dt1, dt4, true);
            Assert.AreEqual(0, dt.Rows.Count);
        }

        [TestMethod]
        public void DataSetComparison_EqualDataTables_WrongOrder_OrderSensitive_ComparisonReturnsResults()
        {
            var dt = DataSetComparison.CompareDataTables(dt1, dt4, true, true);
            //4 because two rows are different on each side.
            Assert.AreEqual(4, dt.Rows.Count);
        }

        [TestMethod]
        public void DataSetComparison_UnequalDataTables_DuplicateRow_ComparisonReturnsResults()
        {
            var dt = DataSetComparison.CompareDataTables(dt1, dt5, true);
            //0 because CompareDataTables with no ordering is a set-based comparison.
            Assert.AreEqual(0, dt.Rows.Count);
        }

        [TestMethod]
        public void DataSetComparison_UnequalDataTables_DuplicateRow_OrderSensitive_ComparisonReturnsResults()
        {
            var dt = DataSetComparison.CompareDataTables(dt1, dt5, true, true);
            Assert.AreEqual(1, dt.Rows.Count);
        }

        [TestMethod]
        public void DataSetComparison_UnequalDataTables_ComparisonReturnsResults()
        {
            var dt = DataSetComparison.CompareDataTables(dt1, dt3, true);
            Assert.AreEqual(4, dt.Rows.Count);
        }

        [TestMethod]
        public void DataSetComparison_DifferentDataTables_ComparisonReturnsResults()
        {
            //We expect failure here because the result sets to compare differ.
            try
            {
                var dt = DataSetComparison.CompareDataTables(dt1, different, true);
                Assert.Fail("No exception hit.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Input string was not in a correct format"));
            }
            
        }

        [TestMethod]
        public void DataSetComparison_FirstDataTableEmpty_ComparisonReturnsResults()
        {
            var dt = DataSetComparison.CompareDataTables(empty, dt2, true);
            Assert.AreEqual(2, dt.Rows.Count);
        }

        [TestMethod]
        public void DataSetComparison_SecondDataTableEmpty_ComparisonReturnsResults()
        {
            var dt = DataSetComparison.CompareDataTables(dt1, empty, true);
            Assert.AreEqual(2, dt.Rows.Count);
        }

        [TestMethod]
        public void DataSetComparison_ExtraLongTables_ComparisonReturnsNoResults()
        {
            var dt = DataSetComparison.CompareDataTables(extralong1, extralong2, true);
            Assert.AreEqual(0, dt.Rows.Count);
        }
    }
}
