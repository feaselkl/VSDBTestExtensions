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
    public class SchemaComparisonTests : SqlDatabaseTestClass
    {

        public SchemaComparisonTests()
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
        public void SchemaComparison_ALL_Match()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_ALL_MatchData;
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
        public void SchemaComparison_1And3_Match()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_1And3_MatchData;
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
        public void SchemaComparison_1To3_Match()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_1To3_MatchData;
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
        [ExpectedException(typeof(System.Exception), "Result Set 3 Column 2 (System.Int32) does not match type for column in Result Set 1 (System.Int16)")]
        [TestMethod()]
        public void SchemaComparison_1To3_Mismatch()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_1To3_MismatchData;
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
        public void SchemaComparison_1To3_Mismatch_Loose_NoException()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_1To3_Mismatch_Loose_NoExceptionData;
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
        [ExpectedException(typeof(System.Exception), "Result Set 2 Column 2 (System.Int16) does not match type for column in Result Set 1 (System.Decimal)")]
        [TestMethod()]
        public void SchemaComparison_ALL_Mismatch_Loose_Exception()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_ALL_Mismatch_Loose_ExceptionData;
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
        public void SchemaComaprsion_ALL_VarcharLengthMismatch_NoException()
        {
            SqlDatabaseTestActions testActions = this.SchemaComaprsion_ALL_VarcharLengthMismatch_NoExceptionData;
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
        public void SchemaComparison_ALL_VarcharNVarcharMismatch_NoException()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_ALL_VarcharNVarcharMismatch_NoExceptionData;
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
        [ExpectedException(typeof(System.Exception), "Result Set 2 Column 1 (f1) does not match name for column in Result Set 1 (F1)")]
        [TestMethod()]
        public void SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_Exception()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_ExceptionData;
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
        public void SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoException()
        {
            SqlDatabaseTestActions testActions = this.SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoExceptionData;
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_ALL_Match_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaComparisonTests));
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_1And3_Match_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_1To3_Match_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_1To3_Mismatch_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_1To3_Mismatch_Loose_NoException_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_ALL_Mismatch_Loose_Exception_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComaprsion_ALL_VarcharLengthMismatch_NoException_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_ALL_VarcharNVarcharMismatch_NoException_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_Exception_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoException_TestAction;
            VSDBTestExtensions.SchemaCompareTestCondition schemaCompareTestCondition10;
            this.SchemaComparison_ALL_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComparison_1And3_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComparison_1To3_MatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComparison_1To3_MismatchData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComparison_1To3_Mismatch_Loose_NoExceptionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComparison_ALL_Mismatch_Loose_ExceptionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComaprsion_ALL_VarcharLengthMismatch_NoExceptionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComparison_ALL_VarcharNVarcharMismatch_NoExceptionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_ExceptionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoExceptionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            SchemaComparison_ALL_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition1 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComparison_1And3_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition2 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComparison_1To3_Match_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition3 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComparison_1To3_Mismatch_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition4 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComparison_1To3_Mismatch_Loose_NoException_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition5 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComparison_ALL_Mismatch_Loose_Exception_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition6 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComaprsion_ALL_VarcharLengthMismatch_NoException_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition7 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComparison_ALL_VarcharNVarcharMismatch_NoException_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition8 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_Exception_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition9 = new VSDBTestExtensions.SchemaCompareTestCondition();
            SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoException_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            schemaCompareTestCondition10 = new VSDBTestExtensions.SchemaCompareTestCondition();
            // 
            // SchemaComparison_ALL_Match_TestAction
            // 
            SchemaComparison_ALL_Match_TestAction.Conditions.Add(schemaCompareTestCondition1);
            resources.ApplyResources(SchemaComparison_ALL_Match_TestAction, "SchemaComparison_ALL_Match_TestAction");
            // 
            // schemaCompareTestCondition1
            // 
            schemaCompareTestCondition1.Enabled = true;
            schemaCompareTestCondition1.IsCaseSensitive = false;
            schemaCompareTestCondition1.IsLooseComparison = false;
            schemaCompareTestCondition1.Name = "schemaCompareTestCondition1";
            schemaCompareTestCondition1.ResultSets = "ALL";
            // 
            // SchemaComparison_1And3_Match_TestAction
            // 
            SchemaComparison_1And3_Match_TestAction.Conditions.Add(schemaCompareTestCondition2);
            resources.ApplyResources(SchemaComparison_1And3_Match_TestAction, "SchemaComparison_1And3_Match_TestAction");
            // 
            // schemaCompareTestCondition2
            // 
            schemaCompareTestCondition2.Enabled = true;
            schemaCompareTestCondition2.IsCaseSensitive = false;
            schemaCompareTestCondition2.IsLooseComparison = false;
            schemaCompareTestCondition2.Name = "schemaCompareTestCondition2";
            schemaCompareTestCondition2.ResultSets = "1,3";
            // 
            // SchemaComparison_1To3_Match_TestAction
            // 
            SchemaComparison_1To3_Match_TestAction.Conditions.Add(schemaCompareTestCondition3);
            resources.ApplyResources(SchemaComparison_1To3_Match_TestAction, "SchemaComparison_1To3_Match_TestAction");
            // 
            // schemaCompareTestCondition3
            // 
            schemaCompareTestCondition3.Enabled = true;
            schemaCompareTestCondition3.IsCaseSensitive = false;
            schemaCompareTestCondition3.IsLooseComparison = false;
            schemaCompareTestCondition3.Name = "schemaCompareTestCondition3";
            schemaCompareTestCondition3.ResultSets = "1:3";
            // 
            // SchemaComparison_1To3_Mismatch_TestAction
            // 
            SchemaComparison_1To3_Mismatch_TestAction.Conditions.Add(schemaCompareTestCondition4);
            resources.ApplyResources(SchemaComparison_1To3_Mismatch_TestAction, "SchemaComparison_1To3_Mismatch_TestAction");
            // 
            // schemaCompareTestCondition4
            // 
            schemaCompareTestCondition4.Enabled = true;
            schemaCompareTestCondition4.IsCaseSensitive = false;
            schemaCompareTestCondition4.IsLooseComparison = false;
            schemaCompareTestCondition4.Name = "schemaCompareTestCondition4";
            schemaCompareTestCondition4.ResultSets = "1:3";
            // 
            // SchemaComparison_1To3_Mismatch_Loose_NoException_TestAction
            // 
            SchemaComparison_1To3_Mismatch_Loose_NoException_TestAction.Conditions.Add(schemaCompareTestCondition5);
            resources.ApplyResources(SchemaComparison_1To3_Mismatch_Loose_NoException_TestAction, "SchemaComparison_1To3_Mismatch_Loose_NoException_TestAction");
            // 
            // schemaCompareTestCondition5
            // 
            schemaCompareTestCondition5.Enabled = true;
            schemaCompareTestCondition5.IsCaseSensitive = false;
            schemaCompareTestCondition5.IsLooseComparison = true;
            schemaCompareTestCondition5.Name = "schemaCompareTestCondition5";
            schemaCompareTestCondition5.ResultSets = "1:3";
            // 
            // SchemaComparison_ALL_Mismatch_Loose_Exception_TestAction
            // 
            SchemaComparison_ALL_Mismatch_Loose_Exception_TestAction.Conditions.Add(schemaCompareTestCondition6);
            resources.ApplyResources(SchemaComparison_ALL_Mismatch_Loose_Exception_TestAction, "SchemaComparison_ALL_Mismatch_Loose_Exception_TestAction");
            // 
            // schemaCompareTestCondition6
            // 
            schemaCompareTestCondition6.Enabled = true;
            schemaCompareTestCondition6.IsCaseSensitive = false;
            schemaCompareTestCondition6.IsLooseComparison = true;
            schemaCompareTestCondition6.Name = "schemaCompareTestCondition6";
            schemaCompareTestCondition6.ResultSets = "ALL";
            // 
            // SchemaComparison_ALL_MatchData
            // 
            this.SchemaComparison_ALL_MatchData.PosttestAction = null;
            this.SchemaComparison_ALL_MatchData.PretestAction = null;
            this.SchemaComparison_ALL_MatchData.TestAction = SchemaComparison_ALL_Match_TestAction;
            // 
            // SchemaComparison_1And3_MatchData
            // 
            this.SchemaComparison_1And3_MatchData.PosttestAction = null;
            this.SchemaComparison_1And3_MatchData.PretestAction = null;
            this.SchemaComparison_1And3_MatchData.TestAction = SchemaComparison_1And3_Match_TestAction;
            // 
            // SchemaComparison_1To3_MatchData
            // 
            this.SchemaComparison_1To3_MatchData.PosttestAction = null;
            this.SchemaComparison_1To3_MatchData.PretestAction = null;
            this.SchemaComparison_1To3_MatchData.TestAction = SchemaComparison_1To3_Match_TestAction;
            // 
            // SchemaComparison_1To3_MismatchData
            // 
            this.SchemaComparison_1To3_MismatchData.PosttestAction = null;
            this.SchemaComparison_1To3_MismatchData.PretestAction = null;
            this.SchemaComparison_1To3_MismatchData.TestAction = SchemaComparison_1To3_Mismatch_TestAction;
            // 
            // SchemaComparison_1To3_Mismatch_Loose_NoExceptionData
            // 
            this.SchemaComparison_1To3_Mismatch_Loose_NoExceptionData.PosttestAction = null;
            this.SchemaComparison_1To3_Mismatch_Loose_NoExceptionData.PretestAction = null;
            this.SchemaComparison_1To3_Mismatch_Loose_NoExceptionData.TestAction = SchemaComparison_1To3_Mismatch_Loose_NoException_TestAction;
            // 
            // SchemaComparison_ALL_Mismatch_Loose_ExceptionData
            // 
            this.SchemaComparison_ALL_Mismatch_Loose_ExceptionData.PosttestAction = null;
            this.SchemaComparison_ALL_Mismatch_Loose_ExceptionData.PretestAction = null;
            this.SchemaComparison_ALL_Mismatch_Loose_ExceptionData.TestAction = SchemaComparison_ALL_Mismatch_Loose_Exception_TestAction;
            // 
            // SchemaComaprsion_ALL_VarcharLengthMismatch_NoExceptionData
            // 
            this.SchemaComaprsion_ALL_VarcharLengthMismatch_NoExceptionData.PosttestAction = null;
            this.SchemaComaprsion_ALL_VarcharLengthMismatch_NoExceptionData.PretestAction = null;
            this.SchemaComaprsion_ALL_VarcharLengthMismatch_NoExceptionData.TestAction = SchemaComaprsion_ALL_VarcharLengthMismatch_NoException_TestAction;
            // 
            // SchemaComaprsion_ALL_VarcharLengthMismatch_NoException_TestAction
            // 
            SchemaComaprsion_ALL_VarcharLengthMismatch_NoException_TestAction.Conditions.Add(schemaCompareTestCondition7);
            resources.ApplyResources(SchemaComaprsion_ALL_VarcharLengthMismatch_NoException_TestAction, "SchemaComaprsion_ALL_VarcharLengthMismatch_NoException_TestAction");
            // 
            // schemaCompareTestCondition7
            // 
            schemaCompareTestCondition7.Enabled = true;
            schemaCompareTestCondition7.IsCaseSensitive = false;
            schemaCompareTestCondition7.IsLooseComparison = false;
            schemaCompareTestCondition7.Name = "schemaCompareTestCondition7";
            schemaCompareTestCondition7.ResultSets = "ALL";
            // 
            // SchemaComparison_ALL_VarcharNVarcharMismatch_NoExceptionData
            // 
            this.SchemaComparison_ALL_VarcharNVarcharMismatch_NoExceptionData.PosttestAction = null;
            this.SchemaComparison_ALL_VarcharNVarcharMismatch_NoExceptionData.PretestAction = null;
            this.SchemaComparison_ALL_VarcharNVarcharMismatch_NoExceptionData.TestAction = SchemaComparison_ALL_VarcharNVarcharMismatch_NoException_TestAction;
            // 
            // SchemaComparison_ALL_VarcharNVarcharMismatch_NoException_TestAction
            // 
            SchemaComparison_ALL_VarcharNVarcharMismatch_NoException_TestAction.Conditions.Add(schemaCompareTestCondition8);
            resources.ApplyResources(SchemaComparison_ALL_VarcharNVarcharMismatch_NoException_TestAction, "SchemaComparison_ALL_VarcharNVarcharMismatch_NoException_TestAction");
            // 
            // schemaCompareTestCondition8
            // 
            schemaCompareTestCondition8.Enabled = true;
            schemaCompareTestCondition8.IsCaseSensitive = false;
            schemaCompareTestCondition8.IsLooseComparison = false;
            schemaCompareTestCondition8.Name = "schemaCompareTestCondition8";
            schemaCompareTestCondition8.ResultSets = "ALL";
            // 
            // SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_ExceptionData
            // 
            this.SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_ExceptionData.PosttestAction = null;
            this.SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_ExceptionData.PretestAction = null;
            this.SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_ExceptionData.TestAction = SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_Exception_TestAction;
            // 
            // SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_Exception_TestAction
            // 
            SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_Exception_TestAction.Conditions.Add(schemaCompareTestCondition9);
            resources.ApplyResources(SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_Exception_TestAction, "SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_Exception_TestAction");
            // 
            // schemaCompareTestCondition9
            // 
            schemaCompareTestCondition9.Enabled = true;
            schemaCompareTestCondition9.IsCaseSensitive = true;
            schemaCompareTestCondition9.IsLooseComparison = false;
            schemaCompareTestCondition9.Name = "schemaCompareTestCondition9";
            schemaCompareTestCondition9.ResultSets = "ALL";
            // 
            // SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoExceptionData
            // 
            this.SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoExceptionData.PosttestAction = null;
            this.SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoExceptionData.PretestAction = null;
            this.SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoExceptionData.TestAction = SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoException_TestAction;
            // 
            // SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoException_TestAction
            // 
            SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoException_TestAction.Conditions.Add(schemaCompareTestCondition10);
            resources.ApplyResources(SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoException_TestAction, "SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoException_TestAction");
            // 
            // schemaCompareTestCondition10
            // 
            schemaCompareTestCondition10.Enabled = true;
            schemaCompareTestCondition10.IsCaseSensitive = false;
            schemaCompareTestCondition10.IsLooseComparison = false;
            schemaCompareTestCondition10.Name = "schemaCompareTestCondition10";
            schemaCompareTestCondition10.ResultSets = "ALL";
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

        private SqlDatabaseTestActions SchemaComparison_ALL_MatchData;
        private SqlDatabaseTestActions SchemaComparison_1And3_MatchData;
        private SqlDatabaseTestActions SchemaComparison_1To3_MatchData;
        private SqlDatabaseTestActions SchemaComparison_1To3_MismatchData;
        private SqlDatabaseTestActions SchemaComparison_1To3_Mismatch_Loose_NoExceptionData;
        private SqlDatabaseTestActions SchemaComparison_ALL_Mismatch_Loose_ExceptionData;
        private SqlDatabaseTestActions SchemaComaprsion_ALL_VarcharLengthMismatch_NoExceptionData;
        private SqlDatabaseTestActions SchemaComparison_ALL_VarcharNVarcharMismatch_NoExceptionData;
        private SqlDatabaseTestActions SchemaComparison_ALL_CaseSensitive_ColumnCaseDiffers_ExceptionData;
        private SqlDatabaseTestActions SchemaComparison_ALL_CaseInsensitive_ColumnCaseDifference_NoExceptionData;
    }
}
