using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Models;
//In MVC, an Action is a function in a Controller class that handles incoming HTTP requests and generates responses.
//A ViewResult is a View that is rendered to the response.
//By default, the action method name is the same as the view name.
namespace SampleMvcApp.Controllers
{
    public class FirstExampleController : Controller
    {
        public Employee GetEmployee()
        {
            var emp = new Employee()
            {
                EmpId = 101,
                EmpName = "John Doe",
                EmpEmail = "john@gmail.com",
                EmpSalary = 45000
            };
            return emp;
        }

        public ViewResult Display()
        {
            var model = GetEmployee();
            //View is a method of Controller class that returns a ViewResult object to the browser
            return View(model);

        }
        public double AddNumbers()
        {
            var num = 123 + 123;
            return num;
        }
       public string Welcome()
       {
           return "<h1>Welcome to ASP.NET Core MVC!</h1>";
        }
    }
}
