﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine("Action - Index Action");
            return RedirectToAction("Management");
        }

        public IActionResult Management()
        {
            /*  People.Add(new Person() { FirstName = "Test", LastName = "Tester" });
                People.Add(new Person() { FirstName = "Person", LastName = "Manager" });
            */
            Debug.WriteLine("Action - Management Action");

            ViewBag.People = People;
            return View();
        }

        public IActionResult Create(string firstName, string lastName)
        {
            Debug.WriteLine($"DATA - Create Person");

            CreatePerson(firstName, lastName);
            return RedirectToAction("Management");
        }

        public IActionResult Delete(string firstName, string lastName)
        {
            Debug.WriteLine($"DATA - Delete Person {firstName}");

            DeletePersonByFirstName(firstName);
            return RedirectToAction("Management");
        }

        public static List<Person> People = new List<Person>();

        // These methods are for data management. The body of the methods will be replaced with EF code tomorrow, but  for now we're just using a static list. 
        public void CreatePerson(string firstName, string lastName)
        {
            Debug.WriteLine($"DATA - CreatePerson({firstName}, {lastName})");
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
