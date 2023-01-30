
using Markt10.DataAccess.Data;
using Markt10.Models;
using Markt10.ViewModel.OrderViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Markt10.Areas.Customer.Controllers
{
    public class OrderController : Controller
    {
        private readonly Markt10DbContext _db;
        public OrderController(Markt10DbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            var model = new OrderView();
            List<Order> orderdb = _db.Orders.ToList();
            List<Product> productdb = _db.Products.ToList();
            var obj = from order in orderdb
                      join product in productdb on order.ProductId equals product.Id
                      select new OrderViewModel
                      {
                          ProductList = product,
                          OrderList = order
                      };
            model.OrderList = obj.ToList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int id)
        {
            var obj = _db.Orders.FirstOrDefault(u => u.Id == id);
            _db.Orders.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        
    }
}
