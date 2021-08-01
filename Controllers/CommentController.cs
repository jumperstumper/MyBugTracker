using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Data;
using WebApplication20.ViewModel;

namespace WebApplication20.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult aComment(CommentVM obj)
        {
            int ticketId = obj.Ticket.Ticket_Id;

            if (ModelState.IsValid)
            {
                _db.Commenents.Add(obj.Comment);
                _db.SaveChanges();
                
            }

            return View();
        }
    }
}
