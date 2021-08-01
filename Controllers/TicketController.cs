using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TicketController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {

            IEnumerable<Ticket> objList = _db.Tickets;

            foreach (var obj in objList)
            {
                obj.Project = _db.Projects.FirstOrDefault(u => u.Project_Id == obj.Project_Id);
            }

            return View(objList);

        }

        public IActionResult AllTickets(int id)
        {

            var objList = _db.Tickets.Include(n => n.Project).ToList();


            return View(objList);

        }



        public ActionResult Info(int id)
        {

            CommentVM t = new CommentVM 
            { 
                Comment = new Comments { Ticket_Id = id },


                UserTicketList = _db.UserTickets.Include(n => n.ApplicationUser).Include(n => n.Ticket)
                .Where(n => n.Ticket_Id == id).ToList(),

                UserTicket = new UserTicket()
                {
                    Ticket_Id = id
                },

                Ticket = _db.Tickets.FirstOrDefault(n => n.Ticket_Id == id)

            };

            t.Ticket = _db.Tickets.FirstOrDefault(t => t.Ticket_Id == id);
            if (t.Ticket == null)
            {
                t.Ticket = new Ticket();
            }
            t.Comments = _db.Commenents.Where(f => f.Ticket_Id == id);

            List<string> tempListOfAssignedUsers = t.UserTicketList.Select(n => n.UserId).ToList();
            //Not in LINQ clause
            var tempList = _db.ApplicationUser.Where(n => !tempListOfAssignedUsers.Contains(n.Id)).ToList();

            t.DevList = tempList.Select(i => new SelectListItem
            {
                Text = i.Email,
                Value = i.Id.ToString()
            });

            //


            return View(t);

        }

        [HttpPost]
        public IActionResult AddDevToTicket(CommentVM commentVM)
        {
           
            _db.UserTickets.Add(commentVM.UserTicket);
            _db.SaveChanges();

            return RedirectToAction(nameof(Info), new { @id = commentVM.Ticket.Ticket_Id });
        }

        [HttpPost]
        public IActionResult RemoveUser(string userId, CommentVM commentVM)
        {
            int ticketId = commentVM.Ticket.Ticket_Id;
            UserTicket userTicket = _db.UserTickets.FirstOrDefault(u => u.UserId == userId && u.Ticket_Id == ticketId);
            _db.UserTickets.Remove(userTicket);
            _db.SaveChanges();

            return RedirectToAction(nameof(Info), new { @id = ticketId });
        }


        public IActionResult Create(int? id)
        {
            TicketVM obj = new TicketVM();

            // Lists
            #region

            // Status List
            List<SelectListItem> statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem()
            {
                Value = "Open",
                Text = "Open"
            });
            statusList.Add(new SelectListItem()
            {
                Value = "Closed",
                Text = "Closed"
            });

            // End Status List



            // Ticket type
            List<SelectListItem> ticketType = new List<SelectListItem>();
            ticketType.Add(new SelectListItem()
            {
                Value = "Bug/Error",
                Text = "Bug/Error"
            });
            ticketType.Add(new SelectListItem()
            {
                Value = "Feature Request",
                Text = "Feature Request"
            });
            ticketType.Add(new SelectListItem()
            {
                Value = "Other",
                Text = "Other"
            });
            // End Ticket Type

            // Ticket Prio List
            List<SelectListItem> ticketPrio = new List<SelectListItem>();
            ticketPrio.Add(new SelectListItem()
            {
                Value = "High",
                Text = "High"
            });
            ticketPrio.Add(new SelectListItem()
            {
                Value = "Medium",
                Text = "Medium"
            });
            ticketPrio.Add(new SelectListItem()
            {
                Value = "Low",
                Text = "Low"
            });

            // End Ticket Prio List

            // project list
            obj.ProjectList = _db.Projects.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Project_Id.ToString()
            });

            #endregion
            // End Lists
            obj.TicketPrioList = ticketPrio;
            obj.TicketTypeList = ticketType;
            obj.StatusList = statusList;
            if (id == null)
            {
                return View(obj);
            }
            if (obj == null)
            {
                return NotFound();
            }
            obj.Ticket = _db.Tickets.FirstOrDefault(u => u.Ticket_Id == id);
            return View(obj);
        }


        // POST Create/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TicketVM obj)
        {

            if (obj.Ticket.Ticket_Id == 0)
            {
                _db.Tickets.Add(obj.Ticket);
            }
            else
            {
                _db.Tickets.Update(obj.Ticket);
            }



            _db.SaveChanges();
            return RedirectToAction("Index", "Project");

        }

     

        // Delete

        public IActionResult Delete(int? id)
        {
            var dbObj = _db.Tickets.FirstOrDefault(u => u.Ticket_Id == id);
            _db.Tickets.Remove(dbObj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Project");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Comments(CommentVM obj)
        {

            if (ModelState.IsValid)
            {                
                _db.Commenents.Add(obj.Comment);
                _db.SaveChanges();
            }

            return RedirectToAction("Info", new
            {
                id = obj.Ticket.Ticket_Id
            });


        }

        
      
      
    }

 
}


