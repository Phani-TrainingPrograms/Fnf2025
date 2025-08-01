--Stored Procedures are sp statements that are pre-parsed and can be used like a function. As the statements inside the Stored Proc are processed, it shall execute directly without a need to reparse it. This optimizes the execution and will be helpful for App Developers for optimizing their apps while connecting with databases.
alter Procedure InsertEmp(
	@name nvarchar(50),
	@address nvarchar(50),
	@salary money,
	@deptId int,
	@generatedEmpId int OUTPUT)
AS
INSERT INTO Employee VALUES(@name, @address, @salary, @deptId)
SET @generatedEmpId = @@IDENTITY
PRINT @@IDENTITY

DECLARE @id INT
EXEC	 [dbo].[InsertEmp]
		@name = N'Jane Austin',
		@address = N'Chicago',
		@salary = 5000,
		@deptId = 6,
		@generatedEmpId = 0

SElECT * FROM EMPLOYEE WHERE EmpName = 'Donald Trump'

----------------------------------UPDATE PROC-----------------------------------------------
Alter Procedure UpdateEmp(
	@empId int,
	@name nvarchar(50),
	@address nvarchar(200),
	@salary money,
	@deptId int)
AS 
  UPDATE  EMPLOYEE SET EmpName = @name, EmpAddress = @address, EmpSalary = @salary,  DeptId = @deptId WHERE EmpId = @empId
IF @@ROWCOUNT = 1 --@@ROWCOUNT is a builtin variable to get the no of rows affected. 
 PRINT 'Employee updated successfully'
ELSE
 PRINT 'Employee could not be found'

EXEC dbo.UpdateEmp
		@empId = 10308,
		@name = N'Donald Trump',
		@address = N'New York',
		@salary = 50000, 
		@deptId = 7

