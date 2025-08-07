using SampleLib.DataLayer;
using SampleLib.Entities;
using SampleWinConsole.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//LINQ is a library for performing queries on objects, XML and other kinds of data. It has been extended to even SQL server. 
//If U can get a collection of data from an external source, U can perform database kind of queries(Reading) from the collection instead of reading the whole collection all the time. LINQ help in optimizing the search in the collection and returns the specific data from the master collection. 
//LINQ was introduced in .NET 3.5 and made full fledged in .NET 4.0.
//LINQ comes with a set of keywords(from, group, order, by, where, select) as well as Extension methods that is applicable on all Collection classes. 
//A Collection class is one that implements IEnumerable<T> interface. 
//Extension methods are methods that are added at runtime to the instance without breaking the class. 
//LINQ Extension methods are available under System.Linq. 

namespace SampleWinConsole
{
    /// <summary>
    /// Example on Extension methods.
    /// </summary>
    static class MyExtensions
    {
        /// <summary>
        /// Example on Method extended to String clas
        /// </summary>
        /// <param name="input">The String type to which this method is extended.</param>
        /// <returns>The no of words</returns>
        public static int GetWords(this string input)
        {
            //Every extension method must be static. It can return types. The arg list must have the 1st arg as this followed by the class and its variable to which this method is extended. 
            var words = input.Split(' ', ',', ';');
            return words.Length;
        }
    }

    static class CsvHelper
    {
        public static List<Product> GetAllProducts()
        {
            var fileName = "C:\\Trainings\\FnfTraining\\FnFTraining-2025\\CSharpBasics\\SampleWinConsole\\SampleData.csv";
            var lines = File.ReadAllLines(fileName);
            var products = new List<Product>();
            foreach(var line in lines)
            {
                var words = line.Split(',');
                var product = new Product();
                product.Id = Convert.ToInt32(words[0]);
                product.Description = words[1];
                product.Amount = Convert.ToDouble(words[2]);
                product.Date = DateTime.ParseExact(words[3], "M/d/yyyy", null);
                products.Add(product);
            }
            return products;
        } 

    }
    internal class Ex04linqExample
    {
        static List<Employee> masterData = new EmployeeDB().GetAllEmployees();
        static List<Dept> masterDepts = new EmployeeDB().GetAllDepts();

        static void Main(string[] args)
        {
            //extensionmethodUsage();

            //readonlyDescriptions();
            //readDescAndDate();
            //readNamesAndSalarys();
            //readNamesFromAddress("San Jose");
            //getEmployeesByGroups();
            //groupEmployeesAlphabettically();
            //joinExample();
            //joinExampleGroupedByDept();
            joinAllEmployeesWithDepts();
        }

        private static void joinAllEmployeesWithDepts()
        {
            var results = from emp in masterData
                          join dept in masterDepts
                          on emp.DeptId equals dept.DeptId into gr
                          from subDept in gr.DefaultIfEmpty() // This is a left outer join.
                          select new
                          {
                              emp.EmpName,
                              emp.EmpSalary,
                              emp.EmpAddress,
                              DeptName = subDept?.DeptName ?? "No Department"
                          };
            foreach(var emp in results)
            {
                Console.WriteLine($"{emp.EmpName} is working in {emp.DeptName}");
            }
            //defaultIfEmpty() ensure that if no matching record is found in the Dept table, it will return a null value for that record.  
        }

        private static void joinExampleGroupedByDept()
        {
            //todo: Create a join between Employee and Dept tables and group the results by DeptName. 
            var results = from emp in masterData
                          join dept in masterDepts
                          on emp.DeptId equals dept.DeptId
                          group new { emp, dept } by dept.DeptName
                          into gr
                          orderby gr.Key ascending
                          select gr;
            foreach(var group in results)
            {
                Console.WriteLine("Employees under: " + group.Key);
                foreach(var rec in group)
                {
                    Console.WriteLine($"{rec.emp.EmpName} earns {rec.emp.EmpSalary}");
                }
                Console.WriteLine("\n\n\n");
            }
        }

        /// <summary>
        /// Example of EquiJoin using LINQ.
        /// </summary>
        private static void joinExample()
        {
            var results = from emp in masterData join dept in masterDepts 
                          on emp.DeptId equals dept.DeptId
                          select new
                          {
                              emp.EmpName,
                              emp.EmpSalary,
                              emp.EmpAddress,
                              dept.DeptName
                          };
            foreach(var emp in results)
            {
                Console.WriteLine($"{emp.EmpName} from {emp.DeptName}");
            }
        }

        private static string GetSecondOrFirstName(string empName)
        {
            int firstSpace = empName.IndexOf(' ');
            if(firstSpace < 0) return empName;
            int secondSpace = empName.IndexOf(' ', firstSpace + 1);
            if(secondSpace < 0)
                return empName.Substring(firstSpace + 1);
            return empName.Substring(firstSpace + 1, secondSpace - firstSpace - 1);
        }
        private static void groupEmployeesAlphabettically()
        {
            var groups = from emp in masterData
                         orderby (emp.EmpName.Split(' ').Length > 1 ? emp.EmpName.Split(' ')[1] : emp.EmpName.Split(' ')[0]) ascending
                         group emp by emp.EmpName[0]
                         into gr
                         orderby gr.Key ascending
                         select gr;
            foreach(var group in groups)
            {
                Console.WriteLine("Employee names under " + group.Key);
                foreach(var emp in group)
                {
                    Console.WriteLine($"{emp.EmpName} earns {emp.EmpSalary:C}");
                }
            }
        }

        private static void getEmployeesByGroups()
        {
            var results = from emp in masterData
                          orderby emp.EmpName
                          group emp.EmpName by emp.EmpAddress
                          into gr
                          orderby gr.Key
                          select gr;
            foreach(var gr in results)
            {
                Console.WriteLine("Employees in " + gr.Key);
                foreach(var name in gr)
                {
                    Console.Write($"{name},  ");
                }
                Console.WriteLine("\n\n");
            }
            //todo: Create groups based on Alphabets of the FirstName. 
        }

        private static void readNamesFromAddress(string v)
        {
            Console.WriteLine($"Master Count: {masterData.Count}");
            var results = from emp in masterData
                          where emp.EmpAddress.ToLower() == v.ToLower() && emp.EmpSalary > 75000
                          select new { Name = emp.EmpName, Salary = emp.EmpSalary };
            //LINQ executes only in the foreach statement, not before it.
            Console.WriteLine($"Where count: {results.Count()}");
            foreach(var res in results) Console.WriteLine(res);
        }

        private static void readNamesAndSalarys()
        {
            //var masterData = CsvHelper.GetAllProducts();
            var results = from rec in masterData
                          orderby rec.EmpSalary descending
                          select new { rec.EmpName, rec.EmpSalary };
            foreach(var item in results)
            {
                Console.WriteLine(item);
            }
        }

        private static void readNamesAndAddress()
        {
            //var masterData = CsvHelper.GetAllProducts();
            var results = from rec in masterData
                          select new { rec.EmpName, rec.EmpAddress };
            foreach(var result in results)
            {
                Console.WriteLine($"{result.EmpName} on {result.EmpAddress}");
            }
        }

        private static void readonlyNames()
        {
            var results = from emp in masterData
                          select emp.EmpName;
            foreach(var desc in results)
            {
                Console.WriteLine(desc);
            }
        }

        private static void extensionmethodUsage()
        {
            string sentence = "If U can get";
            int count = sentence.GetWords();
            Console.WriteLine("The no of words: " + count);
        }
    }
}
