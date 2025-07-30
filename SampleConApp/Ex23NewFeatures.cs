using System;
namespace SampleConApp
{
    //var keyword, Anonymous types, Anonymous methods, Lambda Functions and expressions. 
	class Ex23NewFeatures
	{
        static Action<double> action;
        static void Main(string[] args)
        {
            //anonymousMethodExample();

            //usingVarKeyword();

            //usingAnonymousDataTypes();

            //LambdaFunctionsExample();

            usingLambdaInList();
        }
       // static int id = 0;
        private static void usingLambdaInList()
        {
            var list = new List<Employee>
            {
                new Employee { EmpID = 1, EmpName = "John", EmpAddress = "New York", EmpSalary = 50000, Designation = "Manager" },
                new Employee { EmpID = 2, EmpName = "Jane", EmpAddress = "Los Angeles", EmpSalary = 60000, Designation = "Developer" },
                new Employee { EmpID = 3, EmpName = "Sam", EmpAddress = "Chicago", EmpSalary = 55000, Designation = "Designer" }
            };

            var id = ConsoleUtil.GetInputInt("Enter the Id of the Employee to search");
            //var predicate = new Predicate<Employee>((rec) => rec.EmpID == id);
            var foundRec  = list.Find((rec) => rec.EmpID == id);
            if(foundRec == null)
            {
                Console.WriteLine("No record found with the given Id");
                return;
            }
            Console.WriteLine($"{foundRec.EmpName}");
        }

        //static bool Finder(Employee employee)
        //{
        //    return employee.EmpID == id; 
        //}
        private static void LambdaFunctionsExample()
        {
            double value = ConsoleUtil.GetInputDouble("Enter a double value");
            action = (x) => Console.WriteLine("The input for this function is " + x);
           
            if(action != null)
                action(value);
        }
        private static void anonymousMethodExample()
        {
            double value = ConsoleUtil.GetInputDouble("Enter a double value");
            //action = new Action<double>(callThis); //=>.NET 1.0v(2002)
            //action = callThis; //=>.NET 1.1v(2003)
            action = delegate (double x) //=>.NET 2.0v(2005)
            {
                Console.WriteLine("The input for this function is " + x);
            };//assigning a method directly to the delegate instace. 
            if(action != null)
                action(value);
        }

        static void callThis(double v1)
        {
            Console.WriteLine("The input for this function is " + v1);
        }

        //Anonymous types are objects created without an class definition. They are objects that contain only properties. They dont have methods, they behave like data carriers. 
        //Introduced in .NET 3.5(2010).
        private static void usingAnonymousDataTypes()
        {
            var temp = new { Name = "Phaniraj", Address = "Bangalore", PinCode = 560098 };
            Console.WriteLine($"The values are {temp.Name} from {temp.Address} with PinCode as {temp.PinCode}");
            //When extracting data from a database object, we can extract only those set of data that we want and ignore others. 
            Console.WriteLine("The data type of temp is " + temp.GetType().Name);
        }

        //var is a keyword to represent local variables in a convinient manner. 
        //It is also called as Implicit Typed variable. It gets the data type based on what it is assigned to. 
        //It must be assigned at the declaration statement itself. 
        //It cannot be used as field, property, parameter of a function or a return type of a function. 
        //It is a convinient way of using local variables without compromising on the type safety. 
        //U dont need unboxing while working with var. 

        private static void usingVarKeyword()
        {
            var temp = new Employee();
    
            //temp is an object of the type Employee and all the rules of a Type safe variable is applicable to it. 
            //temp = 123;//Error as the temp is an employee, which is not the case in object.
            Console.WriteLine("The data type is " + temp.GetType().Name);
        }
    }
}