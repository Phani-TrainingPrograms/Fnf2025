using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvcApp.Models
{
    [Table("CstTable")]
    public class Customer
    {
        [Key]
        public int CstId { get; set; }

        [Required]
        public string CstName { get; set; }
        [Required]
        public string CstAddress { get; set; }
        [Required]
        public double BillAmount { get; set; }
    }

    public class CstDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=FnfTraining;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }
 
    }
}
