using Markt10.DataAccess.Data;
using Markt10.Repository.IRepository;
using Markt10.ViewModel.HomeViewModel;

namespace Markt10.Repository
{
    public class Phone : IPhone
    {
        private readonly Markt10DbContext _db;
        public Phone(Markt10DbContext db)
        {
            _db = db;
        }

        public IEnumerable<PhoneView> Color_Filter(List<int> color_filter)
        {
            var phone = from phones in _db.Phones
                        join product in _db.Products on phones.ProductId equals product.Id
                        join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                        join category in _db.Categories on product.CategoryId equals category.Id
                        join color in _db.Colors on product.ColorId equals color.Id
                        where color_filter.Any(x => x == color.Id)
                        select new PhoneView
                        {
                            PhoneList = phones,
                            ProductList = product,
                            TrademarkList = trademark,
                            CategoryList = category
                        };
            return phone;
        }

        

        public IEnumerable<PhoneView> GetAll()
        {
            var phone = from phones in _db.Phones
                        join product in _db.Products on phones.ProductId equals product.Id
                        join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                        join category in _db.Categories on product.CategoryId equals category.Id
                        select new PhoneView
                        {
                            PhoneList = phones,
                            ProductList = product,
                            TrademarkList = trademark,
                            CategoryList = category
                        };
            return phone;
        }

        public IEnumerable<PhoneView> GetById(int id)
        {
            var phone = from phones in _db.Phones
                        join product in _db.Products on phones.ProductId equals product.Id
                        join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                        join category in _db.Categories on product.CategoryId equals category.Id
                        where category.Id == id
                        select new PhoneView
                        {
                            PhoneList = phones,
                            ProductList = product,
                            TrademarkList = trademark,
                            CategoryList = category
                        };
            return phone;
        }

        public IEnumerable<PhoneView> GetByPrice(int min, int max)
        {
            var phone = from phones in _db.Phones
                        join product in _db.Products on phones.ProductId equals product.Id
                        join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                        join category in _db.Categories on product.CategoryId equals category.Id
                        where product.Price < max && product.Price > min
                        select new PhoneView
                        {
                            PhoneList = phones,
                            ProductList = product,
                            TrademarkList = trademark,
                            CategoryList = category
                        };
            return phone;
        }

        public IEnumerable<PhoneView> Search(string search)
        {
            var phone = from phones in _db.Phones
                        join product in _db.Products on phones.ProductId equals product.Id
                        join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                        join category in _db.Categories on product.CategoryId equals category.Id
                        where product.Name.Contains(search.ToUpper())
                        select new PhoneView
                        {
                            PhoneList = phones,
                            ProductList = product,
                            TrademarkList = trademark,
                            CategoryList = category
                        };
            return phone;
        }

        public IEnumerable<PhoneView> Trademark_Filter(List<int> trademark_filter)
        {
            var phone = from phones in _db.Phones
                        join product in _db.Products on phones.ProductId equals product.Id
                        join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                        join category in _db.Categories on product.CategoryId equals category.Id
                        where trademark_filter.Any(x => x == trademark.Id)
                        select new PhoneView
                        {
                            PhoneList = phones,
                            ProductList = product,
                            TrademarkList = trademark,
                            CategoryList = category
                        };
            return phone;
        }
    }
}
