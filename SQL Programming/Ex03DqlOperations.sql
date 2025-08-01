Select * from Employee --all records
select * from Employee where EmpAddress = 'San Jose'

Select * from Employee where EmpAddress like 'San%'
Select * from Employee where EmpAddress like 'San%' and EmpSalary > 80000
-------------SQL Server scalar value functions------------------
Select Max(EmpSalary) as MaxSalary , Min(EmpSalary) as MinSalary, Avg(EmpSalary) asAvgSalary from Employee -- Scalar Value functions are those functions created in SQL server for returning single values. Functions can be used as expressions within the SQL statements. 

Select Top(10)EmpName, EmpSalary from Employee
Order by EmpSalary DESC

Select top 50 percent * from Employee

Select * from
(Select Top 50 percent * from Employee Order by EmpId Desc) Temp
Order by EmpId Asc

----------Joins for combining data from multiple tables--------------
Select Employee.*, DeptTable.DeptName from Employee, DeptTable where Employee.DeptId = DeptTable.DeptId

Select EmpName, EmpSalary, DeptName from Employee 
join DeptTable 
on Employee.DeptId = DeptTable.DeptId 



Declare @numRows int = 50;

With RandomRows AS(SELECT TOP (@numRows) * From Employee)
Update RandomRows Set DeptId = null

Select Count(*) as NullEmployees from Employee where DeptId  is null

------------------Left join, it gets all the rows of the left table and only the matching rows of the right table-------------------
Select EmpName, EmpSalary, COALESCE(DeptName, 'Not Assigned') as DeptName from Employee left join DeptTable
on Employee.DeptId = DeptTable.DeptId
--COALESCE is like a IFF condition, where the value is not available, U can replace it with a certain value. 

--Add few depts taht dont belong to any Employee
Insert into DeptTable values('HOuse keeping')
Insert into DeptTable values('IT Team')
---Right Jion is to get all the right side data and only matching left side data. 

SElect Employee.*, DeptTable.DeptName from Employee
right join DeptTable 
on Employee.DeptId = DeptTable.DeptId
-----------------group by clause---
--get the employee count by city. 
Select EmpAddress, Count(EmpName) as EmpCount  from Employee
group by EmpAddress 
Order by EmpAddress
--If U want to use group by, the selection should have either aggregate functions or all columns on which the grouping is done. 

--Get the distribution of salaries in each city with city with highest salary should come first. 
Select EmpAddress, Sum(EmpSalary) as TotalSalaries from Employee
group by EmpAddress order by TotalSalaries Desc


---Employees whose salary is more than the avg sal of that city. 
Select e.EmpName, e.EmpAddress, e.EmpSalary, Avgsalaries.avgSalary as AvgSalary from Employee e
JOIN
(SElECT Employee.EmpAddress, Avg(Employee.EmpSalary) as avgSalary
FROM EMPLOYEE GROUP BY EmpAddress) as Avgsalaries
on e.EmpAddress = Avgsalaries.EmpAddress
WHERE e.EmpSalary > Avgsalaries.avgSalary
 







