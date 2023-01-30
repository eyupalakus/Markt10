
using Markt10.DataAccess.Data;
using Markt10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Markt10.ViewModel.HomeView;
using Markt10.ViewModel.HomeViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Markt10.Repository.IRepository;

namespace Markt10.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly Markt10DbContext _db;
        public HomeController(IUnitofWork unitofwork, Markt10DbContext db)
        {
            _unitofWork = unitofwork;
            _db = db;
        }

        public IActionResult Index(string search)
        {

            var model = new HomeViewModel();

            List<Product> products = _db.Products.ToList();
            List<Category> categories = _db.Categories.ToList();
            List<Trademark> trademarks = _db.Trademarks.ToList();
            if(search != null)
            {
                var accessory = _unitofWork.accessory.Search(search);
                var computer = _unitofWork.computer.Search(search);
                var housefold = _unitofWork.housefold.Search(search);
                var phone = _unitofWork.phone.Search(search);
                var tv = _unitofWork.tv.Search(search);

                model.AccessoryView = accessory.ToList();
                model.TvView = tv.ToList();
                model.PhoneView = phone.ToList();
                model.ComputerView = computer.ToList();
                model.HousefoldView = housefold.ToList();
            }
            else
            {
                var accessory = _unitofWork.accessory.GetAll();
                var computer = _unitofWork.computer.GetAll();
                var housefold = _unitofWork.housefold.GetAll();
                var phone = _unitofWork.phone.GetAll();
                var tv = _unitofWork.tv.GetAll();

                model.AccessoryView = accessory.ToList();
                model.TvView = tv.ToList();
                model.PhoneView = phone.ToList();
                model.ComputerView = computer.ToList();
                model.HousefoldView = housefold.ToList();
            }
            
            var trade = _db.Trademarks.ToList();
            var color = _db.Colors.ToList();
            var category_db = _db.Categories.ToList();
            var product_db = _db.Products.ToList();

            model.Color = color;
            model.Trademark = trade;
            model.Category = category_db;
            model.Product = product_db;

            return View(model);
        }
        
        [HttpPost]
        public IActionResult Price(int min = 0, int max = 0)
        {

            var model = new HomeViewModel();

            List<Accessory> accessories = _db.Accessories.ToList();
            List<Product> products = _db.Products.ToList();
            List<Category> categories = _db.Categories.ToList();

            if (max == 0)
            {
                max = 9999;
            }


            var accessory = _unitofWork.accessory.GetByPrice(min, max);
            var computer = _unitofWork.computer.GetByPrice(min, max);
            var housefold = _unitofWork.housefold.GetByPrice(min, max);
            var phone = _unitofWork.phone.GetByPrice(min, max);
            var tv = _unitofWork.tv.GetByPrice(min, max);
            var trade = _db.Trademarks.ToList();
            var color = _db.Colors.ToList();
            var category_db = _db.Categories.ToList();
            var product_db = _db.Products.ToList();

            model.Color = color;
            model.Trademark = trade;
            model.Category = category_db;
            model.Product = product_db;
            model.AccessoryView = accessory.ToList();
            model.TvView = tv.ToList();
            model.PhoneView = phone.ToList();
            model.ComputerView = computer.ToList();
            model.HousefoldView = housefold.ToList();

            return View("Index",model);
        }
        public IActionResult Trademark(List<int> trademark_filter = null)
        {

            var model = new HomeViewModel();

            List<Accessory> accessories = _db.Accessories.ToList();
            List<Product> products = _db.Products.ToList();
            List<Category> categories = _db.Categories.ToList();

            var accessory = _unitofWork.accessory.Trademark_Filter(trademark_filter);
            var computer = _unitofWork.computer.Trademark_Filter(trademark_filter);
            var housefold = _unitofWork.housefold.Trademark_Filter(trademark_filter);
            var phone = _unitofWork.phone.Trademark_Filter(trademark_filter);
            var tv = _unitofWork.tv.Trademark_Filter(trademark_filter);
            var trade = _db.Trademarks.ToList();
            var color = _db.Colors.ToList();
            var category_db = _db.Categories.ToList();
            var product_db = _db.Products.ToList();

            model.Color = color;
            model.Trademark = trade;
            model.Category = category_db;
            model.Product = product_db;
            model.AccessoryView = accessory.ToList();
            model.TvView = tv.ToList();
            model.PhoneView = phone.ToList();
            model.ComputerView = computer.ToList();
            model.HousefoldView = housefold.ToList();

            return View("Index",model);
        }
        public IActionResult Color(List<int> color_filter = null)
        {

            var model = new HomeViewModel();

            List<Accessory> accessories = _db.Accessories.ToList();
            List<Product> products = _db.Products.ToList();
            List<Category> categories = _db.Categories.ToList();

            var accessory = _unitofWork.accessory.Color_Filter(color_filter);
            var computer = _unitofWork.computer.Color_Filter(color_filter);
            var housefold = _unitofWork.housefold.Color_Filter(color_filter);
            var phone = _unitofWork.phone.Color_Filter(color_filter);
            var tv = _unitofWork.tv.Color_Filter(color_filter);
            var trade = _db.Trademarks.ToList();
            var color = _db.Colors.ToList();
            var category_db = _db.Categories.ToList();
            var product_db = _db.Products.ToList();

            model.Color = color;
            model.Trademark = trade;
            model.Category = category_db;
            model.Product = product_db;
            model.AccessoryView = accessory.ToList();
            model.TvView = tv.ToList();
            model.PhoneView = phone.ToList();
            model.ComputerView = computer.ToList();
            model.HousefoldView = housefold.ToList();

            return View("Index", model);
        }
        public IActionResult Create(int productId)
        {
            Cart cart = new()
            {
                Count = 1,
                ProductId = productId,
                Product = _db.Products.FirstOrDefault(i => i.Id == productId)
            };

            return View(cart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(Cart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            cart.UserId = claim.Value;
            _db.Carts.Add(cart);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}