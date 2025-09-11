using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        { 
        }
        public DbSet<Product> Products { get; set; }
    }
}
