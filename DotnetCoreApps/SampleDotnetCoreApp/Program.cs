namespace SampleDotnetCoreApp
{
    using SampleDotnetCoreApp.Data;
    //Dotnet Core is a cross-platform framework for building modern applications. U can develop Console, web, desktop, mobile, gaming, IoT, AI, and ML applications using .NET Core. It is open-source and maintained by Microsoft and the .NET community on GitHub.
    //Dotnet Core supports multiple programming languages, including C#, F#, and Visual Basic. It also provides a rich set of libraries and frameworks for building various types of applications.
    //For database programming we use Entity Framework Core (EF Core) which is an Object-Relational Mapping (ORM) framework that allows developers to work with databases using .NET objects. It supports various database providers, including SQL Server, SQLite, PostgreSQL, and MySQL.
    //For Web, we can use ASP.NET Core, which is a cross-platform framework for building web applications and APIs. It provides a modular architecture, built-in dependency injection, and support for various web technologies, including Razor Pages, MVC, and Blazor.
    //Blazor is a framework for building interactive web applications using C# and .NET. It allows developers to build client-side web applications using WebAssembly or server-side web applications using SignalR. It is based on the component model, which allows developers to build reusable UI components that can be shared across different applications.
    //EF Core use .NET CLI for database migrations and updates. The .NET CLI provides a set of commands for managing EF Core migrations, including adding, removing, and applying migrations to the database.
    //.NET Core is similar to .NET Framework, but it is designed to be cross-platform and modular. It provides a more lightweight and flexible approach to building applications, allowing developers to choose the components they need for their specific use case.
    //Instead of App.config or Web.config files, .NET Core uses appsettings.json and environment variables for configuration. This allows for a more flexible and modern approach to configuration management. json is platform-independent and can be easily edited and managed across different environments.
    //.NET CORE uses Nuget Packages for package management. NuGet is a package manager for .NET that allows developers to easily add, update, and manage third-party libraries and tools in their projects. NuGet packages are typically hosted on the NuGet Gallery, which is a public repository of packages that can be accessed from within Visual Studio or the .NET CLI.
    //.NET CLI gives a set of commands for managing NuGet packages, including installing, updating, and removing packages from a project. The .NET CLI also provides a way to create and publish NuGet packages, making it easy for developers to share their own libraries and tools with the community.
    //For connecting to databases using EF core, we need the following nuget packages:
    //Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dbContext = new BookContext();
                var newBook = new Book
                {
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    BookPrice = 10
                };
                dbContext.MyBooks.Add(newBook);
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
