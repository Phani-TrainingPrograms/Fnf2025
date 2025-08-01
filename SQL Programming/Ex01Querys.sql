--sql or Structured Query language is a programming language for databases. Its open source and is developed internally by the DB Vendors like MS, Oracle and many more. Prominent are MS and Oracle. 
--SQL Server is a product of MS for database management system. Available since 1995, it is very popular in the market and is useful for enterprise level database management. 
--The Sql version used in MS SQL server is called as T-SQL(Transact SQL). 
-- All Databases are designed based on principles called as Normalization. It is recommended to follow at least 3 Degrees of Normalization. This shall help you in creating robust databases with high level of optimization and management. 
--UR database is a collection of tables and each table is a collection of rows and columns. Columns represent the labels for the data along with the data type that is used for the data. Rows represent a data combination that refers to a real world entity. 
--The 1st deg of normalization expects to have a column with unique data and represents the data it refers. This is called as PRIMARY KEY. A table can have combination of primary key(Composite Primary keys). The column that represents the primary key must be unique . When a primary key is created for a table, indexing becomes easy and it shall be fast in retrival of the data. This is called Clustered Indexing making the data retrivals fast.  
-- If any column has repeated data, U can extract that part into a seperate table and refer it thru foreign key. This is called as relational data. Any primary key column of another table can be refered in the current table as foreign key. As the repeated data column is now into a seperate table, that column could be created with Primary key and refered in the current table. 
-- If there is a composite data (Many to Many) we can segregate the data into 2 tables and create another table as link table to map the data of the 2 tables. 
--SQL divides the language into 5 parts: DCL(Data Control Language), DML(Data Manipulation Language), DDL(Data Definition Language), TCL(Transaction control language), DQL(Data Query Language).
--DDL is used for creating new dbs, tables, stored procedures, functions any many other database objects. 
--Dml is used for data manipulations like insert, delete and update. 
-- DCL is for providing permissions, conditions, constraints etc. 
--DQL is used for performing queries like select, groupings, sorting etc. 
--TCL is used for transaction management where we want to execute a batch of statements as a single unit. if any of the statements fail, then it shall rollback all the statements even the executed ones. either all the statements must succeed or none of the statements shall succeed. 
--SQL server is a database of databases. It has a server unit which represents a unique machine where the SQL server is installed in the network. The SQL server has 4 system dbs that is used by SQL server to manage itself. master(Credentials, User accounts and many other tables required for managing the server), model(defines the templates for various db objects in the instance of the SQL server), msdb(Internal db management), tempdb(Temporory database for storing data for a brief period for the server session).
--The user must be a part of the master db to create or manupulate the databases. 
Create database SampleDb
--Databases are created from the Master database. U can get into master database using 'use' keyword.
use SampleDb -- From now on, any db calls U make shall be executed on the using database. 

Create table Employee--name of the table
(
	EmpId int Primary key, --name data type constraits(rules).
	EmpName nvarchar(50) NOT NULL, 
	EmpAddress nvarchar(200) NOT NULL, 
	EmpSalary money NOT NULL
)

--to delete the table U can drop it
Drop table Employee
use master
Drop database SampleDb -- Used for deleting the database. U cannot delete an using database, U must move out to another database and then execute the Drop command. U cannot drop system databases. 
--to know the currently available dbs in the server, we can use Stored procedure of SQL server sp_databases
sp_databases
use master
drop database FnfTraining
create database FnfTraining
go
use FnfTraining
GO
Create table Employee--name of the table
(
	EmpId int Primary key identity(1,1), --name data type constraits(rules).
	EmpName nvarchar(50) NOT NULL, 
	EmpAddress nvarchar(200) NOT NULL, 
	EmpSalary money NOT NULL
)
GO--executes a batch of statements upto the point from the previous go. 
drop table Employee
sp_databases
sp_tables
sp_columns Employee

--create a table called DeptTable with Id and DeptName. I want Id to be auto generated. 
Create table DeptTable
(
 DeptId int primary key identity(1,1),
 DeptName nvarchar(20)
)

--Add a new column into the Employee table
Alter table Employee
Add DeptId int NOT NULL REFERENCES DeptTable(DeptId)--The value in this column shall be only the values from the DeptID of the DeptTable 
--U can also drop the column with alter table.
alter table Employee
drop constraint FK__Employee__DeptId__267ABA7A
Go
alter table Employee
drop column Deptid
go

Insert into DeptTable values('Training')
Insert into DeptTable values('Development')
Insert into DeptTable values('Testing')
Insert into DeptTable values('Administration')
Insert into DeptTable values('Facilities')
Insert into DeptTable values('HR')

Select * from DeptTable

truncate table DeptTable --clear the rows of the table without altering the schema. 

Insert into Employee values('Phaniraj','Bangalore',45000, 1)
Insert into Employee values('Ramesh','Mysore',45000, 2)
Insert into Employee values('Joe','Chicago',45000, 3)
Insert into Employee values('John','London',45000, 1)
Insert into Employee values('Adams','Paris',45000, 4)
Insert into Employee values('Donald','Canberra',45000, 4)

--todo: Drop the Employee Table, create it again with Identity column and add the reference of the DeptId and then write the insert statements 
--options: Create a new column with identity, drop the existing PK constraint, add  the constraint to the new column. 
--drop the old Pk Column. 










