using Markt10.DataAccess.Data;
using Markt10.Repository.IRepository;
using Markt10.ViewModel.HomeViewModel;

namespace Markt10.Repository
{
    public class Housefold : IHousefold
    {
        private readonly Markt10DbContext _db;
        public Housefold(Markt10DbContext db)
        {
            _db = db;
        }

        public IEnumerable<HousefoldView> Color_Filter(List<int> color_filter)
        {
            var housefold = from housefolds in _db.Housefolds
                            join product in _db.Products on housefolds.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            join color in _db.Colors on product.ColorId equals color.Id
                            where color_filter.Any(x => x == color.Id)
                            select new HousefoldView
                            {
                                HousefoldList = housefolds,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return housefold;
        }

        

        public IEnumerable<HousefoldView> GetAll()
        {
            var housefold = from housefolds in _db.Housefolds
                            join product in _db.Products on housefolds.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            select new HousefoldView
                            {
                                HousefoldList = housefolds,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return housefold;
        }

        public IEnumerable<HousefoldView> GetById(int id)
        {
            var housefold = from housefolds in _db.Housefolds
                            join product in _db.Products on housefolds.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            where category.Id == id
                            select new HousefoldView
                            {
                                HousefoldList = housefolds,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return housefold;
        }

        public IEnumerable<HousefoldView> GetByPrice(int min, int max)
        {
            var housefold = from housefolds in _db.Housefolds
                            join product in _db.Products on housefolds.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            where product.Price < max && product.Price > min
                            select new HousefoldView
                            {
                                HousefoldList = housefolds,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return housefold;
        }

        public IEnumerable<HousefoldView> Search(string search)
        {
            var housefold = from housefolds in _db.Housefolds
                            join product in _db.Products on housefolds.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            where product.Name.Contains(search.ToUpper())
                            select new HousefoldView
                            {
                                HousefoldList = housefolds,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return housefold;
        }

        public IEnumerable<HousefoldView> Trademark_Filter(List<int> trademark_filter)
        {
            var housefold = from housefolds in _db.Housefolds
                            join product in _db.Products on housefolds.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            where trademark_filter.Any(x => x == trademark.Id)
                            select new HousefoldView
                            {
                                HousefoldList = housefolds,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return housefold;
        }
    }
}
