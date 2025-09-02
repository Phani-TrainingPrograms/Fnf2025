using Microsoft.EntityFrameworkCore;
using WebApiWithJwt.Models;

namespace WebApiWithJwt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
