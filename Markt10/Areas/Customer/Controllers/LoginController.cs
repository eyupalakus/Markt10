
using Markt10.DataAccess.Data;
using Markt10.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Markt10.Areas.Customer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        [BindProperty]
        public Login UserModel { get; set; }
        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string? returnUrl =null)
        {
           

            if (ModelState.IsValid)
            {
                if(UserModel.user_name =="Admin" && UserModel.password == "weareintern")
                {
                    return RedirectToAction("Index","AdminPanel",
                          new { Area = "Admin" });
                }
                var identityResult = await signInManager.PasswordSignInAsync(UserModel.user_name, UserModel.password, false, false);
                if (identityResult.Succeeded)
                {
                    if(returnUrl ==null || returnUrl == "/")
                    {
                        TempData["success"] = "Welcome";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Username or password false"); 
            }
            return View();
        }

    }
}
