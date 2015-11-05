using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VSDBTestExtensions.UnitTests
{
    [TestClass()]
    public class DataComparisonTests : SqlDatabaseTestClass
    {

        public DataComparisonTests()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        [TestMethod()]
        public void DataComparisonTests_ALL_Match()
        {
            SqlDatabaseTestActions testActions = this.DataComparisonTests_ALL_MatchData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // Execute the test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
            SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // Execute the post-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
            SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }
        [TestMethod()]
        public void DataComparisonTests_1To3_Match()
        {
            SqlDatabaseTestActions testActions = this.DataComparisonTests_1To3_MatchData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void DataComparisonTests_1And3_Match()
        {
            SqlDatabaseTestActions testActions = this.DataComparisonTests_1And3_MatchData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [ExpectedException(typeof(System.Exception), "Result Set 1 and Result Set 3 had 2 mismatched records total")]
        [TestMethod()]
        public void DataComparisonTests_1To3_Mismatch()
        {
            SqlDatabaseTestActions testActions = this.DataComparisonTests_1To3_MismatchData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [ExpectedException(typeof(System.Exception), "Result Set 1 and Result Set 2 had 4 mismatched records total")]
        [TestMethod()]
        public void DataComparisonTests_OrderSensitive_Mismatch()
        {
            SqlDatabaseTestActions testActions = this.DataComparisonTests_OrderSensitive_MismatchData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void DataComparisonTests_OrderInsenstive_Match()
        {
            SqlDatabaseTestActions testActions = this.DataComparisonTests_OrderInsenstive_MatchData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [ExpectedException(typeof(System.Exception), "Result Set 1 and Result Set 2 had 2 mismatched records total")]
        [TestMethod()]
        public void DataComparisonTests_CaseSensitive_Mismatch()
        {
            SqlDatabaseTestActions testActions = this.DataComparisonTests_CaseSensitive_MismatchData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void DataComparisonTests_CaseInsensitive_Match()
        {
            SqlDatabaseTestActions testActions = this.DataComparisonTests_CaseInsensitive_MatchData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }








        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DataComparisonTests_ALL_Match_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataComparisonTests));
            VSDBTestExtensions.DataCompareTestCondition dataCompareTestCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DataComparisonTests_1To3_Match_TestAction;
            VSDBTestExtensions.DataCompareTestCondition dataCompareTestCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DataComparisonTests_1And3_Match_TestAction;
            VSDBTestExtensions.DataCompareTestCondition dataCompareTestCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DataComparisonTests_1To3_Mismatch_TestAction;
            VSDBTestExtensions.DataCompareTestCondition dataCompareTestCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DataComparisonTests_OrderSensitive_Mismatch_TestAction;
            VSDBTestExtensions.DataCompareTestCondition dataCompareTestCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DataComparisonTests_OrderInsenstive_Match_TestAction;
            VSDBTestExtensions.DataCompareTestCondition dataCompareTestCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DataComparisonTests_CaseSensitive_Mismatch_TestAction;
            VSDBTestExtensions.DataCompareTestCondition dataCompareTestCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction DataComparisonTests_CaseInsensitive_Match_TestAction;
            VSDBTestExtensions.DataCompareTestCondition dataCompareTestCondition8;
            this.DataComparisonTests_ALL_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DataComparisonTests_1To3_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DataComparisonTests_1And3_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DataComparisonTests_1To3_MismatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DataComparisonTests_OrderSensitive_MismatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DataComparisonTests_OrderInsenstive_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DataComparisonTests_CaseSensitive_MismatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.DataComparisonTests_CaseInsensitive_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            DataComparisonTests_ALL_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dataCompareTestCondition1 = new VSDBTestExtensions.DataCompareTestCondition();
            DataComparisonTests_1To3_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dataCompareTestCondition2 = new VSDBTestExtensions.DataCompareTestCondition();
            DataComparisonTests_1And3_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dataCompareTestCondition3 = new VSDBTestExtensions.DataCompareTestCondition();
            DataComparisonTests_1To3_Mismatch_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dataCompareTestCondition4 = new VSDBTestExtensions.DataCompareTestCondition();
            DataComparisonTests_OrderSensitive_Mismatch_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dataCompareTestCondition5 = new VSDBTestExtensions.DataCompareTestCondition();
            DataComparisonTests_OrderInsenstive_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dataCompareTestCondition6 = new VSDBTestExtensions.DataCompareTestCondition();
            DataComparisonTests_CaseSensitive_Mismatch_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dataCompareTestCondition7 = new VSDBTestExtensions.DataCompareTestCondition();
            DataComparisonTests_CaseInsensitive_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dataCompareTestCondition8 = new VSDBTestExtensions.DataCompareTestCondition();
            // 
            // DataComparisonTests_ALL_Match_TestAction
            // 
            DataComparisonTests_ALL_Match_TestAction.Conditions.Add(dataCompareTestCondition1);
            resources.ApplyResources(DataComparisonTests_ALL_Match_TestAction, "DataComparisonTests_ALL_Match_TestAction");
            // 
            // dataCompareTestCondition1
            // 
            dataCompareTestCondition1.Enabled = true;
            dataCompareTestCondition1.EnforceOrder = false;
            dataCompareTestCondition1.IsCaseSensitive = false;
            dataCompareTestCondition1.Name = "dataCompareTestCondition1";
            dataCompareTestCondition1.ResultSets = "ALL";
            // 
            // DataComparisonTests_1To3_Match_TestAction
            // 
            DataComparisonTests_1To3_Match_TestAction.Conditions.Add(dataCompareTestCondition2);
            resources.ApplyResources(DataComparisonTests_1To3_Match_TestAction, "DataComparisonTests_1To3_Match_TestAction");
            // 
            // dataCompareTestCondition2
            // 
            dataCompareTestCondition2.Enabled = true;
            dataCompareTestCondition2.EnforceOrder = false;
            dataCompareTestCondition2.IsCaseSensitive = false;
            dataCompareTestCondition2.Name = "dataCompareTestCondition2";
            dataCompareTestCondition2.ResultSets = "1:3";
            // 
            // DataComparisonTests_1And3_Match_TestAction
            // 
            DataComparisonTests_1And3_Match_TestAction.Conditions.Add(dataCompareTestCondition3);
            resources.ApplyResources(DataComparisonTests_1And3_Match_TestAction, "DataComparisonTests_1And3_Match_TestAction");
            // 
            // dataCompareTestCondition3
            // 
            dataCompareTestCondition3.Enabled = true;
            dataCompareTestCondition3.EnforceOrder = false;
            dataCompareTestCondition3.IsCaseSensitive = false;
            dataCompareTestCondition3.Name = "dataCompareTestCondition3";
            dataCompareTestCondition3.ResultSets = "1,3";
            // 
            // DataComparisonTests_1To3_Mismatch_TestAction
            // 
            DataComparisonTests_1To3_Mismatch_TestAction.Conditions.Add(dataCompareTestCondition4);
            resources.ApplyResources(DataComparisonTests_1To3_Mismatch_TestAction, "DataComparisonTests_1To3_Mismatch_TestAction");
            // 
            // dataCompareTestCondition4
            // 
            dataCompareTestCondition4.Enabled = true;
            dataCompareTestCondition4.EnforceOrder = false;
            dataCompareTestCondition4.IsCaseSensitive = false;
            dataCompareTestCondition4.Name = "dataCompareTestCondition4";
            dataCompareTestCondition4.ResultSets = "1:3";
            // 
            // DataComparisonTests_OrderSensitive_Mismatch_TestAction
            // 
            DataComparisonTests_OrderSensitive_Mismatch_TestAction.Conditions.Add(dataCompareTestCondition5);
            resources.ApplyResources(DataComparisonTests_OrderSensitive_Mismatch_TestAction, "DataComparisonTests_OrderSensitive_Mismatch_TestAction");
            // 
            // dataCompareTestCondition5
            // 
            dataCompareTestCondition5.Enabled = true;
            dataCompareTestCondition5.EnforceOrder = true;
            dataCompareTestCondition5.IsCaseSensitive = false;
            dataCompareTestCondition5.Name = "dataCompareTestCondition5";
            dataCompareTestCondition5.ResultSets = "ALL";
            // 
            // DataComparisonTests_OrderInsenstive_Match_TestAction
            // 
            DataComparisonTests_OrderInsenstive_Match_TestAction.Conditions.Add(dataCompareTestCondition6);
            resources.ApplyResources(DataComparisonTests_OrderInsenstive_Match_TestAction, "DataComparisonTests_OrderInsenstive_Match_TestAction");
            // 
            // dataCompareTestCondition6
            // 
            dataCompareTestCondition6.Enabled = true;
            dataCompareTestCondition6.EnforceOrder = false;
            dataCompareTestCondition6.IsCaseSensitive = false;
            dataCompareTestCondition6.Name = "dataCompareTestCondition6";
            dataCompareTestCondition6.ResultSets = "ALL";
            // 
            // DataComparisonTests_CaseSensitive_Mismatch_TestAction
            // 
            DataComparisonTests_CaseSensitive_Mismatch_TestAction.Conditions.Add(dataCompareTestCondition7);
            resources.ApplyResources(DataComparisonTests_CaseSensitive_Mismatch_TestAction, "DataComparisonTests_CaseSensitive_Mismatch_TestAction");
            // 
            // dataCompareTestCondition7
            // 
            dataCompareTestCondition7.Enabled = true;
            dataCompareTestCondition7.EnforceOrder = false;
            dataCompareTestCondition7.IsCaseSensitive = true;
            dataCompareTestCondition7.Name = "dataCompareTestCondition7";
            dataCompareTestCondition7.ResultSets = "ALL";
            // 
            // DataComparisonTests_CaseInsensitive_Match_TestAction
            // 
            DataComparisonTests_CaseInsensitive_Match_TestAction.Conditions.Add(dataCompareTestCondition8);
            resources.ApplyResources(DataComparisonTests_CaseInsensitive_Match_TestAction, "DataComparisonTests_CaseInsensitive_Match_TestAction");
            // 
            // dataCompareTestCondition8
            // 
            dataCompareTestCondition8.Enabled = true;
            dataCompareTestCondition8.EnforceOrder = false;
            dataCompareTestCondition8.IsCaseSensitive = false;
            dataCompareTestCondition8.Name = "dataCompareTestCondition8";
            dataCompareTestCondition8.ResultSets = "ALL";
            // 
            // DataComparisonTests_ALL_MatchData
            // 
            this.DataComparisonTests_ALL_MatchData.PosttestAction = null;
            this.DataComparisonTests_ALL_MatchData.PretestAction = null;
            this.DataComparisonTests_ALL_MatchData.TestAction = DataComparisonTests_ALL_Match_TestAction;
            // 
            // DataComparisonTests_1To3_MatchData
            // 
            this.DataComparisonTests_1To3_MatchData.PosttestAction = null;
            this.DataComparisonTests_1To3_MatchData.PretestAction = null;
            this.DataComparisonTests_1To3_MatchData.TestAction = DataComparisonTests_1To3_Match_TestAction;
            // 
            // DataComparisonTests_1And3_MatchData
            // 
            this.DataComparisonTests_1And3_MatchData.PosttestAction = null;
            this.DataComparisonTests_1And3_MatchData.PretestAction = null;
            this.DataComparisonTests_1And3_MatchData.TestAction = DataComparisonTests_1And3_Match_TestAction;
            // 
            // DataComparisonTests_1To3_MismatchData
            // 
            this.DataComparisonTests_1To3_MismatchData.PosttestAction = null;
            this.DataComparisonTests_1To3_MismatchData.PretestAction = null;
            this.DataComparisonTests_1To3_MismatchData.TestAction = DataComparisonTests_1To3_Mismatch_TestAction;
            // 
            // DataComparisonTests_OrderSensitive_MismatchData
            // 
            this.DataComparisonTests_OrderSensitive_MismatchData.PosttestAction = null;
            this.DataComparisonTests_OrderSensitive_MismatchData.PretestAction = null;
            this.DataComparisonTests_OrderSensitive_MismatchData.TestAction = DataComparisonTests_OrderSensitive_Mismatch_TestAction;
            // 
            // DataComparisonTests_OrderInsenstive_MatchData
            // 
            this.DataComparisonTests_OrderInsenstive_MatchData.PosttestAction = null;
            this.DataComparisonTests_OrderInsenstive_MatchData.PretestAction = null;
            this.DataComparisonTests_OrderInsenstive_MatchData.TestAction = DataComparisonTests_OrderInsenstive_Match_TestAction;
            // 
            // DataComparisonTests_CaseSensitive_MismatchData
            // 
            this.DataComparisonTests_CaseSensitive_MismatchData.PosttestAction = null;
            this.DataComparisonTests_CaseSensitive_MismatchData.PretestAction = null;
            this.DataComparisonTests_CaseSensitive_MismatchData.TestAction = DataComparisonTests_CaseSensitive_Mismatch_TestAction;
            // 
            // DataComparisonTests_CaseInsensitive_MatchData
            // 
            this.DataComparisonTests_CaseInsensitive_MatchData.PosttestAction = null;
            this.DataComparisonTests_CaseInsensitive_MatchData.PretestAction = null;
            this.DataComparisonTests_CaseInsensitive_MatchData.TestAction = DataComparisonTests_CaseInsensitive_Match_TestAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        private SqlDatabaseTestActions DataComparisonTests_ALL_MatchData;
        private SqlDatabaseTestActions DataComparisonTests_1To3_MatchData;
        private SqlDatabaseTestActions DataComparisonTests_1And3_MatchData;
        private SqlDatabaseTestActions DataComparisonTests_1To3_MismatchData;
        private SqlDatabaseTestActions DataComparisonTests_OrderSensitive_MismatchData;
        private SqlDatabaseTestActions DataComparisonTests_OrderInsenstive_MatchData;
        private SqlDatabaseTestActions DataComparisonTests_CaseSensitive_MismatchData;
        private SqlDatabaseTestActions DataComparisonTests_CaseInsensitive_MatchData;
    }
}
