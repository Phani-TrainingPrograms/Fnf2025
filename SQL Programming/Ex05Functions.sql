--Functions are similar to Stored Procs but can be used like expressions within a SQL statement. 
--It is a SVF(Scalar value function) that returns only one value. 
Create Function getEmpCount()
RETURNS integer
AS
BEGIN
	--Declare a variable
	DECLARE @count INT
	--Set the variable with result from a query
	SET @count = (SELECT COUNT(*) From Employee)
	--return that value
	RETURN @count
END

Select dbo.getEmpCount() as EmpCount --Functions are easy to use as they can be a part of the SQL Expressions in the SQL statements. 

---------Function with paramters--------------------
Create function GetDeptName(@id int)
RETURNS VARCHAR(50)
AS
BEGIN
DECLARE @name  varchar(50)
SET @name = (SELECT deptName from DeptTable where DeptId =@id)
RETURN @name
END

Select e.EmpName, dbo.GetDeptName(e.DeptId) as Dept from Employee e


-----------------------------Using Date and Time--------------------
PRINT GetDate()

Create Function CreateDate(@date Date)
RETURNS VARCHAR(20)
AS
BEGIN
DECLARE @retVal varchar(50)
Set @retVal = '' + Cast(Day(@date) as varchar(5)) + '/' + Cast(MONTH(@date) as varchar(14)) + '/' + cast(year(@date) as varchar(5))
RETURN @retVal
END

Print dbo.CreateDate(getDate())

--------------------Age Function-------------------------
--Create GetAge Function that takes dob of Date type as arg and it shall return integer that represents the age calculated for the given dob. 
Create Function getAge(@dob date)
RETURNS INT
AS
BEGIN
--Implementation. 
DECLARE @age int
Set @age = DATEDIFF(year, @dob, GetDate())
RETURN @age
END

Print dbo.getAge('01/12/1976')



