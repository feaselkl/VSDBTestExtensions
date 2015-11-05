# VSDBTestExtensions
Visual Studio Database Unit Test Extensions is a project dedicated to making Visual Studio database unit test projects better.

VSDBTestExtensions includes a suite of test types which you can apply to any database test.  VSDBTestExtensions has two features which make it better than the default set of test options provided with Visual Studio database unit test projects:  new comparison types and result set specification.

##New Comparison Types
VSDBTestExtensions offers three new test types:  Result Set Row Count Match, Result Set Schema Compare, and Result Set Data Compare.  These test types are ideal for the following scenarios:
* You're refactoring a procedure and want to make sure that your new procedure's results match the old procedure's results.
* You have ever-changing data, so you can't hard-code scalar values.  You also don't want to build up complex combinations of temporary tables.  This is especially useful when stored procedure result sets have a large number of columns.

###Result Set Row Count Match
Ensure that all result sets in the comparison set have the same number of rows.

###Result Set Schema Comparison
Ensure that all result sets in the comparison set have the same schema.  This compares number of columns, names of columns, and column data types.  VSDBTestExtensions will allow you to determine whether column names are case sensitive, as well as whether you want "strict" enforcement of data types or "loose" enforcement.  Strict enforcement will cause test failure if, for example, you compare a result set with an INT column (Int32 in .NET code) to a result set with a SMALLINT column (Int16 in .NET code).  Loose enforcement will let all integer-like types (BIGINT, INT, SMALLINT, TINYINT) and all numeric types (DECIMAL, DOUBLE, NUMERIC, MONEY, etc.) be interchangable.

Loose enforcement means that one result set with a column defined as an INT will not cause failure if comparison result set's column type is SMALLINT, but it will cause failure if the comparison result set's column type is DOUBLE, VARCHAR, DATETIME, or anything non-integer.

This is useful in ensuring that your procedure signature does not change when refactoring code.

###Result Set Data Comparison
Ensure that all result sets have the same data values.  This compares individual rows in each result set, looking for differences.  You can determine whether sort order is important.  If so, rows out of order will cause a test to fail; otherwise, as long as the same sets of rows exist, the test will succeed.

Caveat with the result set data comparison:  data comparison is a set-based comparison when the "Order Sensitive" flag is set to False.  This means that all duplicate rows in tables will be smashed down to one for purposes of comparison.  In other words, { 1, 2, 3, 3, 3, 3 } will equate to { 1, 2, 3 }.  Setting "Order Sensitive" to true will change this behavior and { 1, 2, 3, 3, 3, 3 } will not equate to { 1, 2, 3 }.  If you want order insensitivity, consider adding a Result Set Row Count as well.

###Mix And Match
These three test types are independent of one another, meaning that you can add row count, schema, and data comparisons independently, as each of these will cover different scenarios.

##Result Set Specification
VSDBTestExtensions allows you to specify which result sets are eligible for comparison.  You have three options available to you:

###ALL
By default, all result sets will be eligible for comparison.

###Sequence (e.g., 1:4)
If you enter a sequence, each result set in that sequence will be eligible for comparison.

###Comma-Separated List (e.g., 1,3,6)
If you enter a comma-separated list, each result set in that list will be eligible for comparison.
