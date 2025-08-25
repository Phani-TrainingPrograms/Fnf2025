# Entity Framework Core 8.0 with .NET 8.0
## Steps to create and run a sample application
1. Create a new .NET 8.0 console application:
   ```bash
   dotnet new console -n SampleDotnetCoreApp
   cd SampleDotnetCoreApp
   ```
2. Add the required NuGet packages for Entity Framework Core:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   ```
3. Create the data model and DbContext class in the Data folder as explained. Code is shared in the Data folder.
4. Open the Package Manager CLI and run the following commands to create and apply migrations:
   ```
   add-migration InitialCreate
   update-database	
   ``` 
1. In the Program.cs file create the instance of the DBContext object, instance of the Book object that U want to insert into the database and add the code as mentioned in the Program.cs file
5. Run the application to test the results. 