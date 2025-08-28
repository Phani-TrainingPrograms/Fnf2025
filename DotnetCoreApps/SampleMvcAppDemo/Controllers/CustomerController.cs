using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Models;

namespace SampleMvcApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var repo = new CustomerRepo();
            var model = repo.GetAllCustomers();
            return View(model);
        }
    }
}
