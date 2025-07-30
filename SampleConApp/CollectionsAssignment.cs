using CollectionAssignment.DataLayer;
using CollectionAssignment.Entities;
using CollectionAssignment.Utilities;
using SampleConApp;

namespace CollectionAssignment.Entities
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double BillAmount { get; set; }
    }

    enum Operations { Add = 1  , Remove, Update, Find, GetAll }
}
namespace CollectionAssignment.DataLayer
{
    interface ICustomerManager
    {
        void AddCustomer(Customer cst);
        void UpdateCustomer(int id, Customer cst);
        void DeleteCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer FindCustomer(int id);
    }

    class CustomerManager : ICustomerManager
    {
        public void AddCustomer(Customer cst)
        {
            //get the original list from the file. 
            var orignal = GetAllCustomers() as List<Customer>;
            //add the new customer to the list
            orignal.Add(cst);
            //save it back to the file.
            CustomerUtil.SaveAllCustomers(orignal);
        }

        public void DeleteCustomer(int id)
        {
            //get the list
            var original = GetAllCustomers() as List<Customer>;
            var selectedCst = FindCustomer(id);
            if(selectedCst != null)
            {
                original.Remove(selectedCst);
            }
            else
            {
                throw new Exception("Customer not found to delete");
            }
            //save it back
            CustomerUtil.SaveAllCustomers(original);
        }

        public Customer FindCustomer(int id)
        {
            var original = GetAllCustomers() as List<Customer>;
            //remove the element based on the id
            var selectedCst = original.Find(rec => rec.Id == id);
            if(selectedCst != null)
            {
                return selectedCst;
            }
            else
            {
                throw new Exception("Customer does not exist");
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var filePath = CustomerUtil.cstFile;
            var list = new List<Customer>();
            if(!File.Exists(filePath))
            {
                return list;
            }
            var lines = File.ReadAllLines(filePath);
            foreach(string line in lines)
            {
                var words = line.Split(',');
                var cst = new Customer
                {
                    Id = int.Parse(words[0]),
                    Name = words[1],
                    Address = words[2],
                    BillAmount = double.Parse(words[3])
                };
                list.Add(cst);
            }
            return list;
        }

        public void UpdateCustomer(int id, Customer cst)
        {
            //Get the original
            //Update the customer in the original
            //Save it to the File
            var original = GetAllCustomers();
            //todo: Find the guy and modify
            CustomerUtil.SaveAllCustomers(original);
        }
    }
}

namespace CollectionAssignment.UILayer
{
    class CustomerManagementSoftware
    {
        static ICustomerManager mgr = new CustomerManager();
        static void Main(string[] args)
        {
            var menu = CustomerUtil.GetMenu();
            bool processing = false;
            do
            {
                var choice = ConsoleUtil.GetInputInt(menu);
                Operations selectedOption = (Operations)choice;
                processing = processMenu(selectedOption);
                _ = ConsoleUtil.GetInputString("Press ENTER to continue");
                Console.Clear();
            } while(processing);
        }

        private static bool processMenu(Operations operation)
        {
            switch(operation)
            {
                case Operations.Add:
                    addingFeature();
                    break;
                case Operations.Remove:
                    removalFeature();
                    break;
                case Operations.Update:
                    break;
                case Operations.Find:
                    findingFeature();
                    break;
                case Operations.GetAll:
                    displayData();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void findingFeature()
        {
            var id = ConsoleUtil.GetInputInt("Enter the ID of the Customer to find");
            try
            {
                var record = mgr.FindCustomer(id);
                Console.WriteLine($"{record.Name} from {record.Address} has billed {record.BillAmount:C}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void removalFeature()
        {
            int id = ConsoleUtil.GetInputInt("Enter the ID to delete");
            mgr.DeleteCustomer(id);
            Console.WriteLine("Customer deleted successfully");
        }

        private static void displayData()
        {
            var records = mgr.GetAllCustomers();
            foreach(var record in records)
            {
                Console.WriteLine($"{record.Name} from {record.Address} has billed {record.BillAmount:C}");
            }
        }

        private static void addingFeature()
        {
            var id = ConsoleUtil.GetInputInt("Enter the Id");
            var name = ConsoleUtil.GetInputString("Enter the Name");
            string address = ConsoleUtil.GetInputString("Enter the Address");
            var bill = ConsoleUtil.GetInputDouble("Enter the Bill Amount");
            var cst = new Customer { Address = address, BillAmount = bill, Id = id, Name = name };
            mgr.AddCustomer(cst);
            Console.WriteLine("Customer added successfully");
        }
    }
}

namespace CollectionAssignment.Utilities
{
    class CustomerUtil
    {
        const string menuFile = "C:\\Trainings\\FnfTraining\\FnFTraining-2025\\CSharpBasics\\SampleConApp\\Menu.txt";
        public const string cstFile = "C:\\Trainings\\FnfTraining\\FnFTraining-2025\\CSharpBasics\\SampleConApp\\cstFile.csv";
        public static string GetMenu()
        {
            var contents = File.ReadAllText(menuFile);
            return contents;
        }

        public static void SaveAllCustomers(IEnumerable<Customer> customers)
        {
            var lines = string.Empty;
            foreach(var customer in customers)
            {
                var line = $"{customer.Id}, {customer.Name}, {customer.Address}, {customer.BillAmount}\n";
                lines += line ;
            }
            File.WriteAllText(cstFile, lines);
        }

    }
}