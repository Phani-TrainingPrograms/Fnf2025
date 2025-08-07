using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//LINQ to SQL is used to query databases using LINQ syntax. This was the first ORM (Object Relational Mapping) technology introduced by Microsoft. Currently, it is not actively developed, and Entity Framework is the recommended ORM technology. However, LINQ to SQL is still supported in .NET Core and .NET 5+. LINQ to SQL works with SQL Server databases and allows you to map database tables to C# classes, enabling you to work with data in a more object-oriented way.
//Server Explorer is configured with UR Database. 
//Add LINQ to SQL Classes item to the project.
//In the designer, drag and drop the tables you want to work with.
// This will generate the necessary classes and context for LINQ to SQL.
//DataContext is the class that represents the database connection and provides access to the tables in the form of properties. Every table in the database will have a corresponding property in the DataContext class in a pluralized name.
namespace SampleWinConsole
{
    using SampleWinConsole.LinqData;
    internal class Ex06LinqToSqlDemo
    {
        static void Main(string[] args)
        {
            displayAll();
            //insertEmployee();
            //updateEmployee();
            //todo: Handle the delete operation also.
            //showEmpWithDepts();
            showEmployeesOfDept("Training");
        }

        private static void showEmployeesOfDept(string v)
        {
            var context = new EmpDbDataContext();
            var records = context.DeptTables.FirstOrDefault(dept => dept.DeptName == v).Employees;
            foreach(var rec in records)
            {
                Console.WriteLine(rec.EmpName);
            }
        }

        private static void showEmpWithDepts()
        {
            //create context
            var context = new EmpDbDataContext();
            //query the Employees table and join with DeptTable to get the department name.
            var records = from emp in context.Employees
                          join dept in context.DeptTables
                          on emp.DeptId equals dept.DeptId //Join condition
                          select new
                          {
                             Name = emp.EmpName,
                             Dept = dept.DeptName,
                             Salary = emp.EmpSalary
                          };
            //display the data
            foreach(var item in records)
            {
                Console.WriteLine(item);
            }
        }

        private static void updateEmployee()
        {
            //create the Dbcontext.
            var context = new EmpDbDataContext();
            //find the matching record to updaate
            var rec = context.Employees.FirstOrDefault(emp => emp.EmpId == 1); //Assuming EmpId 1 exists in the Employees table.
            //update the values
            rec.EmpName = "Phaniraj B.N.";
            rec.EmpSalary = 78000;
            //save the changes.
            context.SubmitChanges(); //SubmitChanges is used to save the changes to the database.
        }

        private static void insertEmployee()
        {
            //As EmpID is auto generated, we dont need to set it.
            var emp = new Employee //Employee of LINQ DBContext
            {
                EmpName = "Phaniraj",
                EmpAddress = "Bangalore",
                EmpSalary = 60000,
                DeptId = 1 //Assuming DeptId 1 exists in the DeptTable
            };
            var context = new EmpDbDataContext();
            context.Employees.InsertOnSubmit(emp); //InsertOnSubmit is used to add a new record to the Employees table.
            context.SubmitChanges(); //SubmitChanges is used to save the changes to the database.
        }

        private static void displayAll()
        {
            var context = new EmpDbDataContext();
            //var records = from emp in context.Employees
            //              select emp; //Select * from Employee
            //foreach(var emp in records)
            //{
            //    Console.WriteLine(emp.EmpName);
            //}

            var depts = from dept in context.DeptTables
                        select dept; //Select * from DeptTable
            foreach(var item in depts)
            {
                Console.WriteLine(item.DeptName);
            }


        }
    }
}
