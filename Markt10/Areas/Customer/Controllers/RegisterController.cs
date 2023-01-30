
using Markt10.DataAccess.Data;
using Markt10.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Markt10.Areas.Customer.Controllers
{
    public class RegisterController : Controller
    {

        [BindProperty]
        public Register UserModel { get; set; }
        public UserManager<IdentityUser> userManager { get; }
        public SignInManager<IdentityUser> signInManager { get; }

        public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
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
                var user = new IdentityUser()
                {
                    UserName = UserModel.User_Name,
                    Email = UserModel.User_Email
                };
                var result = await userManager.CreateAsync(user, UserModel.User_Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
