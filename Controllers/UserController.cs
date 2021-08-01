using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication20.Data;
using WebApplication20.ViewModel;

namespace WebApplication20.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;


        public UserController(UserManager<IdentityUser> userManager, ApplicationDbContext db, RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;

        }

       

        public IActionResult Index()
        {
            var userList = _db.ApplicationUser.ToList();
            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList) 
            {
                var role = userRoles.FirstOrDefault(u => u.UserId == user.Id);

                if (role == null)
                {
                    user.Role = "None";
                }
                else 
                {
                    user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
                }

                
            }

            return View(userList);
        }

        public IActionResult UserProfile()
        {


            var currentUserId = this.GetCurrentUserId();

            var Tickets = _db.UserTickets
                .Include(n => n.ApplicationUser)
                .Include(n => n.Ticket)
                .Where(n => n.UserId == currentUserId)
                .ToList();


            return View(Tickets);

        }

    

       
           
        

    }

    // Extension Method for UserProfile
    public static class ControllerExtensions
    {
        public static string GetCurrentUserId(this ControllerBase controller)
        {
            try
            {
                var userId = controller.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return userId;
            }
            catch
            {
                throw new Exception("Cannot find user id.");
            }
        }
    }
}
