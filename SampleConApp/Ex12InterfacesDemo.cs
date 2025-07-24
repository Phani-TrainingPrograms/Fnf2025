
//Interface is a set of members that can be implemented by a class. It contains only abstract methods. Interfaces cannot have fields, properties, or constructors. They can have methods, events, and indexers. A class can implement multiple interfaces, allowing for a form of multiple inheritance. Interfaces are used to define a contract that classes must adhere to, promoting loose coupling and flexibility in design.
//interface members cannot have access modifiers. All members of an interface are implicitly public and abstract.
//Purpose of the interface is to define a contract that compells a class that implements it to provide public implementations for the members defined in the interface.
//If an class implements an interface, it means that the class is providing a concrete implementation for all the members defined in the interface. This allows for polymorphism, where a reference of the interface type can be used to refer to an object of the class that implements the interface.
namespace SampleConApp
{
    interface IShow
    {
        void Show();
    }
    class RealShow : IShow
    {
        public void Show()
        {
            Console.WriteLine("RealShow is showing");
        }
    }

    interface IEmployeeRepo
    {
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int empId);
        List<Employee> GetAllEmployees(); 
    }

    class EmpRepo : IEmployeeRepo
    {
        private List<Employee> employees = new List<Employee>(); //CRUD operations
        public void AddEmployee(Employee emp)
        {

            Console.WriteLine("Adding is done");
        }

        public void DeleteEmployee(int empId)
        {
            Console.WriteLine("Deleting is done");

        }

        public List<Employee> GetAllEmployees()
        {
            Console.WriteLine("Getting all");
            return employees;
        }

        public void UpdateEmployee(Employee emp)
        {
            Console.WriteLine("Updating is done");
        }
    }

    internal class RepoCreator
    {
        public static IEmployeeRepo CreateRepo(string type)
        {
            // Here we can decide which implementation to return based on some condition
            // For now, we are returning the concrete implementation directly
            return new EmpRepo();
        }
    }
    internal class Ex12InterfacesDemo
    {
        static void Main(string[] args)
        {
            var repo = RepoCreator.CreateRepo("Employee");
            repo.AddEmployee(new Employee { EmpID = 1, EmpName = "John Doe", EmpAddress = "123 Main St", EmpSalary = 50000, Designation = "Developer" });
            repo.UpdateEmployee(new Employee { });
            repo.DeleteEmployee(1);
            var data = repo.GetAllEmployees();
            Console.WriteLine("EmpCount: " +  data.Count);
        }
    }
}
