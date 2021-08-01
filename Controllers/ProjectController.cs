using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Data;
using WebApplication20.Models;
using WebApplication20.ViewModel;

namespace WebApplication20.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Project> objList = _db.Projects;
            return View(objList);
            
        }

        

        public IActionResult Details(int id) 
        {
          
            IEnumerable<Ticket> obj = _db.Tickets
                .Include(p => p.Project)
                .Where(m => m.Project_Id == id);


            if (id == null)
            {
                return NotFound();
            }

            return View(obj);
         }


        public IActionResult ProjectUsers(int id)
        {

            var projectList = _db.Projects.FirstOrDefault(t => t.Project_Id == id);

            return View(projectList);
        }



        //GET-Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project obj)
        {
            if (ModelState.IsValid)
            {

                _db.Projects.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        // Delete
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(int? id)
        {
            var objFromDb = _db.Projects.FirstOrDefault(u => u.Project_Id == id);
            _db.Projects.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}






