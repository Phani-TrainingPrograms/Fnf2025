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

        public ViewResult NewCustomer()
        {
            var cst = new Customer();
            return View(cst);//Blank Customer object passed.
        }

        [HttpPost]
        public IActionResult NewCustomer(Customer cst)
        {
            if (ModelState.IsValid)
            {
                var repo = new CustomerRepo();
                repo.AddCustomer(cst);
                return RedirectToAction("Index");
            }
            return View(cst);
        }

        public IActionResult EditCustomer(int id)
        {
            var repo = new CustomerRepo();
            var cst = repo.GetCustomerById(id);
            if(cst == null)
            {
                ViewBag.ErrorMessage = "Customer not found to edit";
            }
            return View(cst);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer cst)
        {
            if (ModelState.IsValid)
            {
                var repo = new CustomerRepo();
                try
                {
                    repo.UpdateCustomer(cst);
                }
                catch(Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
                return RedirectToAction("Index");
            }
            return View(cst);
        }
    }
}
