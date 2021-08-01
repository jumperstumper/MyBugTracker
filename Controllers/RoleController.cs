using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Data;

namespace WebApplication20.Controllers
{
    public class RoleController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public RoleController(UserManager<IdentityUser> userManager, ApplicationDbContext db, RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }


        [HttpGet]
        public IActionResult Upsert(string id)
        {
            if (string.IsNullOrEmpty(id)) 
            {
                return View();
            }
            else 
            {
                var objDb = _db.Roles.FirstOrDefault(u => u.Id == id);
                return View(objDb);
            }
        }
    }

}
