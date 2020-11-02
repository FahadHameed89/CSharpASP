using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPTestProject.Models;

namespace ASPTestProject.Controllers
{
    public class HomeController : Controller
    {
        // Controllers are responsible fo rfetching and returning views according to URIs as well as performing data manipulation via an EF Context

        // A method that will return a View (whether directly or through a redirect) is referred to as an 'Action', and will typically return an IActionResult
        // A data manipulation method will look more similar to our EF practice done with a console application
        // With the exception of Home/Index which renders at the root path), pages render at /ControllerName/ActionName ("Home/Privacy for this page's privacy action"). 
        // This is also configurable if you want to change it. 

        // 1 - If we make a new TestPage() and travel to it (Run project -> Add /home/TestPage to end of file extension) you will see a blank page, then an ERROR because we haven't made the page yet. 


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // 'return View()' essentially means just get the view associated with this path and send it to the client. 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TestPage(string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                AddedItems.Add(item);
            }

            ViewBag.Items = AddedItems;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static List<Person> People = new List<Person>();
        public void CreatePerson(string firstName, string lastName)
        {
            People.Add(new Person()
            {
                FirstName = firstName.Trim(),
                LastName = lastName.Trim()
            }
                );
        }

        public void DeletePersonByFirstName(string firstName)
        {
            People.Remove(GetPersonByFirstName(firstName));
        }

        public Person GetPersonByFirstName(string firstName)
        {
            // This ensures nobody's name is duplicated. IF so, it will return null.
            return People.Where(x => x.FirstName.Trim().ToUpper() == firstName.Trim().ToUpper()).SingleOrDefault();
        }

    }
}
