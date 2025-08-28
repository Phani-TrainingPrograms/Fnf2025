namespace SampleMvcApp.Models
{
    public class CustomerRepo
    {
        public void AddCustomer(Customer customer) 
        {
            var context = new CstDbContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            var context = new CstDbContext();
            return context.Customers.ToList();
        }
    }
}
