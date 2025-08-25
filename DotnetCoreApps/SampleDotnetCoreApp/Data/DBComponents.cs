using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleDotnetCoreApp.Data
{
    //In this Example, we are using EF's Code -First approach to define a simple data model for a library system. The model consists of a Entity class called Book that represents real world book. 
    //Like LINQ to SQL, EF Core allows us to query and manipulate data using C# objects and LINQ queries. It uses DBContext class to manage the database connection and perform CRUD operations on the data.
    //Attributes like [Key] and [Required] are used to define the primary key and required properties of the Book entity.
    [Table("Books")]
    internal class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]//NOT NULL
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(50)]
        [Required]
        public string Author { get; set; }
        [Required]
        public int BookPrice { get; set; }
    }

    class BookContext : DbContext
    {
        //"Data Source =.\SQLEXPRESS; Initial Catalog = FnfTraining; Integrated Security = True; Encrypt = False; Trust Server Certificate=True"
        public DbSet<Book> MyBooks { get; set; }

        private const string DB_SOURCE = ".\\SQLEXPRESS"; //Your SQL Server instance name;
        private const string DB_NAME = "FnfTraining";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = $"Data Source={DB_SOURCE};Initial Catalog={DB_NAME};Integrated Security=True;Encrypt=False; Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
//Open the Package Manager Console in Visual Studio and run the following commands to create and apply a migration:
// PM> Add-Migration mig1
// PM> Update-Database