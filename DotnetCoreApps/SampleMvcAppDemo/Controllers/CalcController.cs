using Microsoft.AspNetCore.Mvc;

namespace SampleMvcApp.Controllers
{
    public class CalcController : Controller
    {
        //Once the controller is created, U can add Actions based on the requirement
        //Each action is a method which could be get, post based on the action direction.
        //Values can be passed from the Controller to the view in the following ways: Model-> Only Model per view. ViewData stores the data as a Dictionary and u can access it in the View. ViewBag is a dynamic object thru' which U can access without unboxing it. 

        public IActionResult Index()
        {
            var options = new string[]
            {
                "Add", "Subtract", "Multiply", "Divide"
            };
            ViewData["Options"] = options;
            return View();
        }

        ////////////////////////////This is example for Parameters/////////////////
        [HttpPost]
        public IActionResult Index(string firstValue, string secondValue, string slOptions)
        {
            var options = new string[]
            {
                "Add", "Subtract", "Multiply", "Divide"
            };
            ViewData["Options"] = options;

            var result = 0.0;
            var v1 = double.Parse(firstValue);
            var v2 = double.Parse(secondValue);
            var option = slOptions;
            switch(option)
            {
                case "Add": result = v1 + v2; break;
                case "Subtract": result = v1 - v2; break;
                case "Multiply": result = v1 * v2; break;
                case "Divide": result = v1 / v2; break;
            }
            ViewBag.result = result;
            return View();
        }

        ////////////////////////////This is example for IFormCollection/////////////////

        //[HttpPost]
        //public IActionResult Index(IFormCollection collection)
        //{
        //    var options = new string[]
        //    {
        //        "Add", "Subtract", "Multiply", "Divide"
        //    };
        //    ViewData["Options"] = options;
        //    var result = 0.0;
        //    var v1 = double.Parse(collection["firstValue"]);
        //    var v2 = double.Parse(collection["secondValue"]);
        //    var option = collection["slOptions"];
        //    switch(option)
        //    {
        //        case "Add": result = v1 + v2; break;
        //        case "Subtract": result = v1 - v2; break;
        //        case "Multiply": result = v1 * v2; break;
        //        case "Divide": result = v1 / v2; break;
        //    }
        //    ViewBag.result = result;
        //    return View();
        //}


    }
}
/*
 * From the Controller to View:
 * Model
 * ViewBag ->Dynamic object to store data
 * ViewData->Stores as Dictionary.
 * Both ViewBag and ViewData refer to the same object internally as Dictionary...
 * TempData->Cross Page requests. 
 * 
 * From the View to Controller:
 * Model.
 * FormCollection thru IFormCollection. 
 * Parameters
 */