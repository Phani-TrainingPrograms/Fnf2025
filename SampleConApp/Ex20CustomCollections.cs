using System;
using System.Collections;
using System.Collections.Generic;

namespace SampleConApp.CustomCollections
{
    class Customer//Entity class
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double BillAmount { get; set; }
    }

    //A Collection class is one that holds a collection of objects of a specific type. Its object can be used in a foreach loop.
    //The class must implement the GetEnumerator method, which returns an enumerator that iterates through the collection. This can be achieved by implementing the IEnumerable interface or by providing a custom GetEnumerator method. 
    //GetEnumerator method returns an IEnumerator<T> object that iterates through the collection. It has methods like MoveNext, Reset, and Current(Property) to control the iteration process.
    class CustomerCollection : IEnumerable<Customer> //Repo
    {
        private List<Customer> customers = new List<Customer>();

        //Indexer allows you to access the collection using an index, similar to an array.
        public Customer this[int index]
        {
            get 
            { 
                if(index < 0 || index >= customers.Count)
                {
                    throw new IndexOutOfRangeException("Customer does not exist in this index");
                }
                return customers[index]; 
            } //Indexer to access customers by index
        }
        public void AddCustomer(Customer customer) => customers.Add(customer);

        public Customer GetCustomer(int customerId) => customers.Find(c => c.CustomerId == customerId);

        public void DeleteCustomer(int customerId)
        {
            var customer = GetCustomer(customerId);
            if (customer != null)
            {
                customers.Remove(customer); //exit
                return;
            }
            throw new KeyNotFoundException($"Customer with ID {customerId} not found to delete");
        }
        public List<Customer> GetAllCustomers() => customers;

        public void UpdateCustomer(Customer customer)
        {
            throw new Exception("U must implement the UpdateCustomer method to update customer details");
        }

        // This method returns an enumerator that iterates through the collection. 
        public IEnumerator<Customer> GetEnumerator()
        {
            //IEnumerator<Customer> enumerator = customers.GetEnumerator();//Every colletion class will have a GetEnumerator method that returns an enumerator for the collection.
            //return enumerator;
            foreach (var customer in customers)
            {
                yield return customer; //yield return allows us to return each customer one by one, making it suitable for foreach loops.
            }
        }

        public int Count => customers.Count;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class Ex20CustomCollections
    {
        static void Main(string[] args)
        {
            CustomerCollection repo = new CustomerCollection();
            repo.AddCustomer(new Customer { CustomerId = 1, CustomerName = "John Doe", BillAmount = 100.50 });
            repo.AddCustomer(new Customer { CustomerId = 2, CustomerName = "Jane Smith", BillAmount = 200.75 });
            var customer = repo.GetCustomer(1);
            if(customer != null)
            {
                Console.WriteLine($"Customer Found: {customer.CustomerName}, Bill Amount: {customer.BillAmount}");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
            Console.WriteLine();

            //repo.DeleteCustomer(1);
            //var records = repo.GetAllCustomers();
            //foreach (var cust in records)
            //{
            //    Console.WriteLine($"ID={cust.CustomerId}, Name={cust.CustomerName}, Bill Amount={cust.BillAmount}");
            //}

            //iterating using foreach loop
            foreach(var cust in repo)
            {
                Console.WriteLine(cust.CustomerName);
            }

            //Iterating using IEnumerator object
            var iterator = repo.GetEnumerator();
            while (iterator.MoveNext())
            {
                var currentCustomer = iterator.Current;
                Console.WriteLine($"ID={currentCustomer.CustomerId}, Name={currentCustomer.CustomerName}, Bill Amount={currentCustomer.BillAmount}");
            }
            for(int i =0; i < repo.Count; i++)
            {
                var cust = repo[i];
                Console.WriteLine($"ID={cust.CustomerId}, Name={cust.CustomerName}, Bill Amount={cust.BillAmount}");
            }

        }
    }
}
