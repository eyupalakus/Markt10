
using Markt10.DataAccess.Data;
using Markt10.Models;
using Markt10.ViewModel.CartViewModel;
using Markt10.ViewModel.OrderViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Markt10.Areas.Customer.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly Markt10DbContext _db;
        public CartViewModel CartViewModel { get; set; }
        public CartController(Markt10DbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            
            var model = new CartView();
            List<Product> products = _db.Products.ToList();
            List<Cart> carts = _db.Carts.ToList();
            List<Trademark> trademarks = _db.Trademarks.ToList();
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var obj = from cart in carts
                      join product in products on cart.ProductId equals product.Id
                      join trademark in trademarks on product.TrademarkId equals trademark.Id
                      where cart.UserId == claim.Value
                      select new CartViewModel
                      {
                          ProductList = product,
                          CartList = cart,
                          TrademarkList = trademark
                      };

            foreach (var item in obj)
            {
                model.Total += (item.CartList.Count * item.ProductList.Price);
            }
            model.CartList = obj.ToList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Order()
        {
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var obj = from cart in _db.Carts
                      join product in _db.Products on cart.ProductId equals product.Id
                      join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                      where cart.UserId == claim.Value
                      select new CartViewModel
                      {
                          ProductList = product,
                          CartList = cart,
                          TrademarkList = trademark
                      };
            foreach (var item in obj)
            {
                Order order = new()
                {
                    ProductId = item.ProductList.Id,
                    UserId = item.CartList.UserId,        
                    Count=item.CartList.Count
                };
                _db.Orders.Add(order);
                
            }
            _db.SaveChanges();
            return RedirectToAction("Index","Order");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var query = _db.Carts.FirstOrDefault(x => x.Id == id);
            if (query != null)
            {
                _db.Carts.Remove(query);
                _db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View();
        }

    }
}
