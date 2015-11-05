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
    public class RowCountTestConditionTests : SqlDatabaseTestClass
    {

        public RowCountTestConditionTests()
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
        public void RowCountMatch_ALL_Match()
        {
            SqlDatabaseTestActions testActions = this.RowCountMatch_ALL_MatchData;
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
        public void RowCountMatch_1To3_Match()
        {
            SqlDatabaseTestActions testActions = this.RowCountMatch_1To3_MatchData;
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
        public void RowCountMatch_1And3_Match()
        {
            SqlDatabaseTestActions testActions = this.RowCountMatch_1And3_MatchData;
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
        [ExpectedException(typeof(System.Exception), "Result Set 3: 2 rows does not match the 3 rows in Result Set 1")]
        [TestMethod()]
        public void RowCountMatch_1And3_Mismatch()
        {
            SqlDatabaseTestActions testActions = this.RowCountMatch_1And3_MismatchData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction RowCountMatch_ALL_Match_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowCountTestConditionTests));
            VSDBTestExtensions.RowCountTestCondition rowCountTestCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction RowCountMatch_1To3_Match_TestAction;
            VSDBTestExtensions.RowCountTestCondition rowCountTestCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction RowCountMatch_1And3_Match_TestAction;
            VSDBTestExtensions.RowCountTestCondition rowCountTestCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction RowCountMatch_1And3_Mismatch_TestAction;
            VSDBTestExtensions.RowCountTestCondition rowCountTestCondition4;
            this.RowCountMatch_ALL_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.RowCountMatch_1To3_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.RowCountMatch_1And3_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.RowCountMatch_1And3_MismatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            RowCountMatch_ALL_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountTestCondition1 = new VSDBTestExtensions.RowCountTestCondition();
            RowCountMatch_1To3_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountTestCondition2 = new VSDBTestExtensions.RowCountTestCondition();
            RowCountMatch_1And3_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountTestCondition3 = new VSDBTestExtensions.RowCountTestCondition();
            RowCountMatch_1And3_Mismatch_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountTestCondition4 = new VSDBTestExtensions.RowCountTestCondition();
            // 
            // RowCountMatch_ALL_Match_TestAction
            // 
            RowCountMatch_ALL_Match_TestAction.Conditions.Add(rowCountTestCondition1);
            resources.ApplyResources(RowCountMatch_ALL_Match_TestAction, "RowCountMatch_ALL_Match_TestAction");
            // 
            // RowCountMatch_ALL_MatchData
            // 
            this.RowCountMatch_ALL_MatchData.PosttestAction = null;
            this.RowCountMatch_ALL_MatchData.PretestAction = null;
            this.RowCountMatch_ALL_MatchData.TestAction = RowCountMatch_ALL_Match_TestAction;
            // 
            // rowCountTestCondition1
            // 
            rowCountTestCondition1.Enabled = true;
            rowCountTestCondition1.Name = "rowCountTestCondition1";
            rowCountTestCondition1.ResultSets = "ALL";
            // 
            // RowCountMatch_1To3_MatchData
            // 
            this.RowCountMatch_1To3_MatchData.PosttestAction = null;
            this.RowCountMatch_1To3_MatchData.PretestAction = null;
            this.RowCountMatch_1To3_MatchData.TestAction = RowCountMatch_1To3_Match_TestAction;
            // 
            // RowCountMatch_1To3_Match_TestAction
            // 
            RowCountMatch_1To3_Match_TestAction.Conditions.Add(rowCountTestCondition2);
            resources.ApplyResources(RowCountMatch_1To3_Match_TestAction, "RowCountMatch_1To3_Match_TestAction");
            // 
            // rowCountTestCondition2
            // 
            rowCountTestCondition2.Enabled = true;
            rowCountTestCondition2.Name = "rowCountTestCondition2";
            rowCountTestCondition2.ResultSets = "1:3";
            // 
            // RowCountMatch_1And3_MatchData
            // 
            this.RowCountMatch_1And3_MatchData.PosttestAction = null;
            this.RowCountMatch_1And3_MatchData.PretestAction = null;
            this.RowCountMatch_1And3_MatchData.TestAction = RowCountMatch_1And3_Match_TestAction;
            // 
            // RowCountMatch_1And3_Match_TestAction
            // 
            RowCountMatch_1And3_Match_TestAction.Conditions.Add(rowCountTestCondition3);
            resources.ApplyResources(RowCountMatch_1And3_Match_TestAction, "RowCountMatch_1And3_Match_TestAction");
            // 
            // rowCountTestCondition3
            // 
            rowCountTestCondition3.Enabled = true;
            rowCountTestCondition3.Name = "rowCountTestCondition3";
            rowCountTestCondition3.ResultSets = "1,3";
            // 
            // RowCountMatch_1And3_MismatchData
            // 
            this.RowCountMatch_1And3_MismatchData.PosttestAction = null;
            this.RowCountMatch_1And3_MismatchData.PretestAction = null;
            this.RowCountMatch_1And3_MismatchData.TestAction = RowCountMatch_1And3_Mismatch_TestAction;
            // 
            // RowCountMatch_1And3_Mismatch_TestAction
            // 
            RowCountMatch_1And3_Mismatch_TestAction.Conditions.Add(rowCountTestCondition4);
            resources.ApplyResources(RowCountMatch_1And3_Mismatch_TestAction, "RowCountMatch_1And3_Mismatch_TestAction");
            // 
            // rowCountTestCondition4
            // 
            rowCountTestCondition4.Enabled = true;
            rowCountTestCondition4.Name = "rowCountTestCondition4";
            rowCountTestCondition4.ResultSets = "1,3";
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

        private SqlDatabaseTestActions RowCountMatch_ALL_MatchData;
        private SqlDatabaseTestActions RowCountMatch_1To3_MatchData;
        private SqlDatabaseTestActions RowCountMatch_1And3_MatchData;
        private SqlDatabaseTestActions RowCountMatch_1And3_MismatchData;
    }
}
