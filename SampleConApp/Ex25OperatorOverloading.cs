using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.OperatorOverloading
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }

        //Overloading an operator is done by creating a static method with the keyword 'operator' followed by the operator symbol.
        public static Employee operator + (Employee lhs, int rhs)
        {
            lhs.EmpSalary += rhs;
            return lhs;
        }

        public static Employee operator - (Employee lhs, int rhs)
        {
            lhs.EmpSalary -= rhs;
            return lhs;
        }
    }
}
namespace SampleConApp.OperatorOverloading
{
    using OperatorOverloading;
    //Operator overloading allows to have UR own opertors to be implemented for UR own classes. Usually we overload operators to make the code more readable. 
    internal class Ex25OperatorOverloading
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee { EmpId = 101, EmpName = "John", EmpSalary = 50000 };
            emp1 += 5000;
            emp1 -= 2000;
            Console.WriteLine("The Incremented Salary is " + emp1.EmpSalary);
        }
    }
}
