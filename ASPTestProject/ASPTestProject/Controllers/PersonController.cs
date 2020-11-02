using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPTestProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPTestProject.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Management()
        {
            return View();
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
