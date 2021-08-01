using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Models;
using WebApplication20.ViewModel;

namespace WebApplication20.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole>roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            // Skapa roles
            if(!await _roleManager.RoleExistsAsync("Manager")) 
            {

                await _roleManager.CreateAsync(new IdentityRole("Manager"));
                await _roleManager.CreateAsync(new IdentityRole("Developer"));
            }

            List<SelectListItem> itemsList = new List<SelectListItem>();
            itemsList.Add(new SelectListItem()
            {

                Value = "Manager",
                Text = "Manager"
            });

            itemsList.Add(new SelectListItem()
            {

                Value = "Developer",
                Text = "Developer"
            });

            // Slut Skapa roller

            RegisterVM registervm = new RegisterVM()
            {
                RoleList = itemsList
            };

            return View(registervm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid) 
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) 
                {

                    if (model.RoleSelected!=null && model.RoleSelected.Length>0 && model.RoleSelected == "Manager") 
                    {
                        await _userManager.AddToRoleAsync(user,"Manager");
                    }
                    else 
                    {
                        await _userManager.AddToRoleAsync(user, "Developer");
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
  
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(AccountController.Login),"Account");
        }

        private void AddErrors(IdentityResult result) 
        {
            foreach (var error in result.Errors) 
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        // LOGIN

        [HttpGet]
        public IActionResult Login()
        {
            

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded) 
                {
                   return RedirectToAction("Index", "Home");
                }
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Invaild Login Attempt");
            }
           

            return View(model);
        }

        //LOGIN END

    }
}
