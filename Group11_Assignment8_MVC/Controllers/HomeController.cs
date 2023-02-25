using Group11_Assignment8_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//namespace Group11_Assignment8_MVC.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}




namespace Group11_Assignment8_MVC.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext daContext { get; set; }

        //constructor
        public HomeController(TaskContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = daContext.Categories.ToList(); //setting up variable to hold list of categories in the seed data 

            return View(); //sends user to confirmation page we created
        }


        [HttpPost]
        public IActionResult AddTask(AddTaskResponce ar) //what are we cathing from movieapp.cshtml
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();
                return View("AddTask", ar);     //Will have all information applicationResponse (all user inputs that page)
            }
            else //if invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View(); //chance to redo entries
            }

        }
        [HttpGet]
        public IActionResult Quadrants()
        {
            return View("Quadrants");
        }


        [HttpGet]
        public IActionResult Edit(int TaskId)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var task = daContext.Tasks.Single(x => x.TaskId == TaskId);

            return View("AddTaskResponce", task);
        }
        [HttpPost]
        public IActionResult Edit(AddTaskResponce Blah)
        {
            daContext.Update(Blah);
            daContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var task = daContext.Tasks.Single(x => x.TaskId == TaskId);
            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(AddTaskResponce ar)
        {
            daContext.Tasks.Remove(ar);
            daContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
