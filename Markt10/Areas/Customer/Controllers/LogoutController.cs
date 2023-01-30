using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Markt10.Areas.Customer.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LogoutController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
