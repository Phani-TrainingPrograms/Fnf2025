using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Class is a UDT. It comes with a set of OOP features like Encapsulation, Inheritance, Polymorphism etc.
 * Class can have fields(Data), properties(Accessors), methods(functions), events(Actions), and constructors(Sp Function that is invoked while creating the object). Classes can also be nested.
 * Based on the reason of creation, classes can be categorized into different types like: Entity Classes(Real World Entities), Data Transfer Objects(DTOs for data transfering), View Models(For containing code that works with UI), Service Classes(Functional Classes), Utility Classes(Classes that are used across the Application, usually static) etc.
 */
namespace SampleConApp
{
    class Employee
    {
        //data, shall be private by default
        private int _id;
        string _name;
        string _address;
        double _salary;
        string _designation;

        public int EmpID
        {
            get { return _id; }
            set { _id = value; }//value is the smart keyword that refers to the value being assigned to the property
        }

        public string EmpName
        {
            get { return _name; }
            set { _name = value; }
        }


        public string EmpAddress
        {
            get { return _address; }
            set { _address = value; }
        }


        public double EmpSalary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }
    }

    //Will have methods to perform CRUD operations on Employee class
    class EmployeeRepo
    {
        List<Employee> employees = new List<Employee>(); //CRUD operations
        public void AddEmployee(Employee emp)
        {
            //Code to add employee to the database or collection
            employees.Add(emp);//Add the Employee to the collection.
            Console.WriteLine($"Employee {emp.EmpName} added successfully.");
        }

        public Employee GetEmployee(int empId)
        {
            //Code to get employee from the database or collection
            return employees.Find(emp => emp.EmpID == empId);
            //for(int i = 0; i < employees.Count; i++)
            //{
            //    Employee emp = employees[i]; //Get the employee from the collection
            //    if(emp.EmpID == empId)
            //    {
            //        return emp; //Return the employee if found
            //    }
            //}
        }

        public void UpdateEmployee(Employee emp)
        {
            //Find the matching employee in the collection
            for(int i =0; i < employees.Count; i++)
            {
                if (employees[i].EmpID == emp.EmpID)
                {
                    employees[i] = new Employee();
                    employees[i].EmpID = emp.EmpID;
                    employees[i].EmpName = emp.EmpName;
                    employees[i].EmpAddress = emp.EmpAddress;
                    employees[i].EmpSalary = emp.EmpSalary;
                    employees[i].Designation = emp.Designation; 
                    Console.WriteLine($"Employee {emp.EmpName} updated successfully.");
                    return;
                }
            }
            Console.WriteLine("No Employee found to Update");           
        }

        public void DeleteEmployee(int empId)
        {
            //Code to delete employee from the database or collection
            var rec = employees.Find(emp => emp.EmpID == empId);
            if(rec == null)
            {
                Console.WriteLine($"No Employee found with ID {empId} to delete.");
                return;
            }
            employees.Remove(rec); //Remove the employee from the collection
            Console.WriteLine($"Employee with ID {empId} deleted successfully.");
        }
        public Employee[] GetAllEmployees()
        {
            //Code to get all employees from the database or collection
            return employees.ToArray(); //Convert the List to an array and return
        }
    }
    internal class Ex08ClassesAndObjects
    {
        static EmployeeRepo employeeRepo = new EmployeeRepo();
        static void Main(string[] args)
        {
            bool processing = true;
            do
            {
                Console.WriteLine("Enter the Choice as 1 to Add, 2 to find, 3 to Display All, 4 to Update and 5 to Delete");
                int choice = Convert.ToInt32(Console.ReadLine());
                processing = processMenu(choice);
            }while(processing);
        }

        private static bool processMenu(int choice)
        {
            switch(choice)
            {
                case 1: addEmployee(); return true;
                case 2: findEmployee(); return true;
                case 3: displayAllEmployees(); return true;
                case 4: updateEmployee(); return true;
                case 5: removeEmployee(); return true;
                default: Console.WriteLine("Invalid Choice"); return false;
            }
        }

        private static void removeEmployee()
        {
            throw new NotImplementedException();
        }

        private static void updateEmployee()
        {
            throw new NotImplementedException();
        }

        private static void displayAllEmployees()
        {
            var records = employeeRepo.GetAllEmployees();
            foreach(Employee emp in records)
            {
                Console.WriteLine($"ID={emp.EmpID}, Name={emp.EmpName}, Address={emp.EmpAddress}, Salary={emp.EmpSalary}, Designation={emp.Designation}");
            }
            Console.WriteLine("All Records are displayed");
        }

        private static void findEmployee()
        {
            Console.WriteLine("Enter the Employee ID to find");
            int empId = Convert.ToInt32(Console.ReadLine());
            Employee emp = employeeRepo.GetEmployee(empId);
            if (emp != null)
            {
                Console.WriteLine($"Employee Found: ID={emp.EmpID}, Name={emp.EmpName}, Address={emp.EmpAddress}, Salary={emp.EmpSalary}, Designation={emp.Designation}");
            }
            else
            {
                Console.WriteLine($"No Employee found with ID {empId}");
            }
        }
        private static void addEmployee()
        {
            //todo: take input from user and create an Employee object
            Employee emp = new Employee();
            emp.EmpID = ConsoleUtil.GetInputInt("Enter Employee ID");
            emp.EmpName = ConsoleUtil.GetInputString("Enter Employee Name");
            emp.EmpAddress = ConsoleUtil.GetInputString("Enter Employee Address");
            emp.EmpSalary = ConsoleUtil.GetInputDouble("Enter Employee Salary");
            emp.Designation = ConsoleUtil.GetInputString("Enter Employee Designation");
            employeeRepo.AddEmployee(emp);
        }



    }

    static class ConsoleUtil
    {
        public static string GetInputString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int GetInputInt(string question)
        {
            return int.Parse(GetInputString(question));
        }

        public static double GetInputDouble(string question) => double.Parse(GetInputString(question));
    }
}
