using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instructormanager.Models;
using Instructormanager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instructormanager.Controllers
{ 
   
    public class InstructorController : Controller
    {
        //Dependency injection of IManageInstructor Interface through constructor injection
        private readonly IStudentInstructor _instructorRepository;

        //Constructor which was used for dependency injection
        public InstructorController(IStudentInstructor instructor) => _instructorRepository = instructor;

        public IActionResult Index()
        {
            return View();
        }
      
       // Method to display the list of all Instructors
        public IActionResult List()
        {
            return View(_instructorRepository.Instructors);
        }

        [Authorize]//Authorization property that allows on signed in users
        [HttpGet]
        //Method to Add new Instructor
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.AddInstructor(instructor);
                return View("Details", instructor);
            }
            return View();
        }


        //Method to delete instructor
        [Authorize]
        [HttpGet]
        public IActionResult Delete(long Id)
        {
            Instructor instructor = _instructorRepository.GetInstructor(Id);
            if (instructor == null)
            {
                return RedirectToAction("List");
            }
            return View(instructor);
        }

        //Method to confirm the deletion of instructor
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            var instructor = _instructorRepository.Delete(Id);
            return View("DeletedPage", instructor);
        }

        //Method to get deatils of an instructor
        public IActionResult Details(int Id)
        {
            Instructor instructor = _instructorRepository.GetInstructor(Id);

            return View(instructor);
        }

        //Method to Update/Edit instructor details
        [Authorize]
        [HttpGet]
        public IActionResult Edit(long Id)
        {
         Instructor instructor = _instructorRepository.GetInstructor(Id);
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            _instructorRepository.Update(instructor);

            return RedirectToAction("List", "Instructor");
        }

        //Method to search for an instructor by name,email or any other properties
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string option)
        {

            IQueryable<Instructor> instructor = _instructorRepository.Search(option);

            return View ("SearchResult", instructor);
        }

        //Method that return the search result
        public IActionResult SearchResult()
        {
            return View();
        }
    }
}
