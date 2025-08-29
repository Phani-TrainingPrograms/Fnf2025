
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

        public Customer GetCustomerById(int id)
        {
            var context = new CstDbContext();
            return context.Customers.Find(id);
        }

        internal void UpdateCustomer(Customer cst)
        {
            var context = new CstDbContext();
            var record = context.Customers.Find(cst.CstId);
            if(record != null)
            {
                record.CstName = cst.CstName;
                record.CstAddress = cst.CstAddress;
                record.BillAmount = cst.BillAmount;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
    }
}
