using Markt10.DataAccess.Data;
using Markt10.Repository.IRepository;
using Markt10.ViewModel.HomeViewModel;

namespace Markt10.Repository
{
    public class Tv : ITv
    {
        private readonly Markt10DbContext _db;
        public Tv(Markt10DbContext db)
        {
            _db = db;
        }

        public IEnumerable<TvView> Color_Filter(List<int> color_filter)
        {
            var tvs = from tv in _db.TVs
                      join product in _db.Products on tv.ProductId equals product.Id
                      join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                      join category in _db.Categories on product.CategoryId equals category.Id
                      join color in _db.Colors on product.ColorId equals color.Id
                      where color_filter.Any(x => x == color.Id)
                      select new TvView
                      {
                          TVList = tv,
                          ProductList = product,
                          TrademarkList = trademark,
                          CategoryList = category
                      };
            return tvs;
        }

        

        public IEnumerable<TvView> GetAll()
        {
            var tvs = from tv in _db.TVs
                      join product in _db.Products on tv.ProductId equals product.Id
                      join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                      join category in _db.Categories on product.CategoryId equals category.Id
                      select new TvView
                      {
                          TVList = tv,
                          ProductList = product,
                          TrademarkList = trademark,
                          CategoryList = category
                      };
            return tvs;
        }

        public IEnumerable<TvView> GetById(int id)
        {
            var tvs = from tv in _db.TVs
                      join product in _db.Products on tv.ProductId equals product.Id
                      join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                      join category in _db.Categories on product.CategoryId equals category.Id
                      where category.Id == id
                      select new TvView
                      {
                          TVList = tv,
                          ProductList = product,
                          TrademarkList = trademark,
                          CategoryList = category
                      };
            return tvs;
        }

        public IEnumerable<TvView> GetByPrice(int min, int max)
        {
            var tvs = from tv in _db.TVs
                      join product in _db.Products on tv.ProductId equals product.Id
                      join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                      join category in _db.Categories on product.CategoryId equals category.Id
                      where product.Price < max && product.Price > min
                      select new TvView
                      {
                          TVList = tv,
                          ProductList = product,
                          TrademarkList = trademark,
                          CategoryList = category
                      };
            return tvs;
        }

        public IEnumerable<TvView> Search(string search)
        {
            var tvs = from tv in _db.TVs
                      join product in _db.Products on tv.ProductId equals product.Id
                      join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                      join category in _db.Categories on product.CategoryId equals category.Id
                      where product.Name.Contains(search.ToUpper())
                      select new TvView
                      {
                          TVList = tv,
                          ProductList = product,
                          TrademarkList = trademark,
                          CategoryList = category
                      };
            return tvs;
        }

        public IEnumerable<TvView> Trademark_Filter(List<int> trademark_filter)
        {
            var tvs = from tv in _db.TVs
                      join product in _db.Products on tv.ProductId equals product.Id
                      join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                      join category in _db.Categories on product.CategoryId equals category.Id
                      where trademark_filter.Any(x => x == trademark.Id)
                      select new TvView
                      {
                          TVList = tv,
                          ProductList = product,
                          TrademarkList = trademark,
                          CategoryList = category
                      };
            return tvs;
        }
    }
}
