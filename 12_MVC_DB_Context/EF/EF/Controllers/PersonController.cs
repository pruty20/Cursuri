using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Data;
using Microsoft.AspNetCore.Mvc;

namespace EF.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonContext context;

        public PersonController(PersonContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var persons = context.Persons.ToList();

            return View(persons);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Person());
        }

        [HttpPost]
        public IActionResult Create(Person model)
        {
            if (ModelState.IsValid)
            {
                context.Add(model);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }


        // Get: /Cats/Edit?id
        [HttpGet]  // Atribut
        public IActionResult Edit(int id)
        {
            Person personToEdit = context.Persons.Find(id);
              
            return View(personToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Person model)
        {
            if (ModelState.IsValid)
            {
                var myPerson = context.Persons.Find(model.PersonId);
                TryUpdateModelAsync(myPerson);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }



    }
}