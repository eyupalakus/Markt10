using Markt10.DataAccess.Data;
using Markt10.DataAccess.Repository.IRepository;
using Markt10.ViewModel.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.DataAccess.Repository
{
    public class Accessory : IAccessory
    {
        private readonly Markt10DbContext _db;
        public Accessory(Markt10DbContext db)
        {
            _db = db;
        }

        public IEnumerable<AccessoryView> GetAll()
        {
            var accessory = from acc in _db.Accessories
                            join product in _db.Products on acc.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            select new AccessoryView
                            {
                                AccessoryList = acc,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return accessory;
        }

        public IEnumerable<AccessoryView> Search(string search)
        {
            var accessory = from acc in _db.Accessories
                            join product in _db.Products on acc.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            where product.Name.Contains(search.ToUpper())
                            select new AccessoryView
                            {
                                AccessoryList = acc,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return accessory;
        }

        public IEnumerable<AccessoryView> GetByPrice(int min, int max)
        {
            var accessory = from acc in _db.Accessories
                            join product in _db.Products on acc.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            where product.Price < max && product.Price > min
                            select new AccessoryView
                            {
                                AccessoryList = acc,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return accessory;
        }

        public IEnumerable<AccessoryView> GetById(int id)
        {
            var accessory = from acc in _db.Accessories
                            join product in _db.Products on acc.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            where category.Id == id
                            select new AccessoryView
                            {
                                AccessoryList = acc,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return accessory;
        }

        public IEnumerable<AccessoryView> Trademark_Filter(List<int> trademark_filter)
        {
            var accessory = from acc in _db.Accessories
                            join product in _db.Products on acc.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            where trademark_filter.Any(x => x == trademark.Id)
                            select new AccessoryView
                            {
                                AccessoryList = acc,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return accessory;
        }

        public IEnumerable<AccessoryView> Color_Filter(List<int> color_filter)
        {
            var accessory = from acc in _db.Accessories
                            join product in _db.Products on acc.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            join color in _db.Colors on product.ColorId equals color.Id
                            where color_filter.Any(x => x == color.Id)
                            select new AccessoryView
                            {
                                AccessoryList = acc,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return accessory;
        }
    }
}
