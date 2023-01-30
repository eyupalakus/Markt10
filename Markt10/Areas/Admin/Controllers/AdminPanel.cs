
using Markt10.DataAccess.Data;
using Markt10.Models;
using Markt10.ViewModel.CartViewModel;
using Markt10.ViewModel.OrderViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Markt10.Areas.Admin.Controllers
{
    public class AdminPanel : Controller
    {
        private readonly Markt10DbContext _db;
        public AdminPanel(Markt10DbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            var obj = _db.Orders.ToList();
            return View(obj);
        }
        [HttpPost]
        public IActionResult Deliver()
        {
            var obj = _db.Orders.ToList();
            foreach (var item in obj)
            {
                if (item.Status == false)
                {
                    item.Status = true;
                    _db.Orders.Update(item);
                    _db.SaveChanges();
                }
                
                
            }
            
            return RedirectToAction("Index","AdminPanel");
        }
    }
}
