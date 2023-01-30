using Markt10.DataAccess.Data;
using Markt10.Repository.IRepository;
using Markt10.ViewModel.HomeViewModel;

namespace Markt10.Repository
{
    public class Computer : IComputer
    {
        private readonly Markt10DbContext _db;
        public Computer(Markt10DbContext db)
        {
            _db = db;
        }

        public IEnumerable<ComputerView> Color_Filter(List<int> color_filter)
        {
            var computer = from computers in _db.Computers
                            join product in _db.Products on computers.ProductId equals product.Id
                            join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                            join category in _db.Categories on product.CategoryId equals category.Id
                            join color in _db.Colors on product.ColorId equals color.Id
                            where color_filter.Any(x => x == color.Id)
                            select new ComputerView
                            {
                                ComputerList = computers,
                                ProductList = product,
                                TrademarkList = trademark,
                                CategoryList = category
                            };
            return computer;
        }

        

        public IEnumerable<ComputerView> GetAll()
        {
            var computer = from computers in _db.Computers
                           join product in _db.Products on computers.ProductId equals product.Id
                           join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                           join category in _db.Categories on product.CategoryId equals category.Id
                           select new ComputerView
                           {
                               ComputerList = computers,
                               ProductList = product,
                               TrademarkList = trademark,
                               CategoryList = category
                           };
            return computer;
        }

        public IEnumerable<ComputerView> GetById(int id)
        {
            var computer = from computers in _db.Computers
                           join product in _db.Products on computers.ProductId equals product.Id
                           join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                           join category in _db.Categories on product.CategoryId equals category.Id
                           where category.Id == id
                           select new ComputerView
                           {
                               ComputerList = computers,
                               ProductList = product,
                               TrademarkList = trademark,
                               CategoryList = category
                           };
            return computer;
        }

        public IEnumerable<ComputerView> GetByPrice(int min, int max)
        {
            var computer = from computers in _db.Computers
                           join product in _db.Products on computers.ProductId equals product.Id
                           join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                           join category in _db.Categories on product.CategoryId equals category.Id
                           where product.Price < max && product.Price > min
                           select new ComputerView
                           {
                               ComputerList = computers,
                               ProductList = product,
                               TrademarkList = trademark,
                               CategoryList = category
                           };
            return computer;
        }

        public IEnumerable<ComputerView> Search(string search)
        {
            var computer = from computers in _db.Computers
                           join product in _db.Products on computers.ProductId equals product.Id
                           join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                           join category in _db.Categories on product.CategoryId equals category.Id
                           where product.Name.Contains(search.ToUpper())
                           select new ComputerView
                           {
                               ComputerList = computers,
                               ProductList = product,
                               TrademarkList = trademark,
                               CategoryList = category
                           };
            return computer;
        }

        public IEnumerable<ComputerView> Trademark_Filter(List<int> trademark_filter)
        {
            var computer = from computers in _db.Computers
                           join product in _db.Products on computers.ProductId equals product.Id
                           join trademark in _db.Trademarks on product.TrademarkId equals trademark.Id
                           join category in _db.Categories on product.CategoryId equals category.Id
                           where trademark_filter.Any(x => x == trademark.Id)
                           select new ComputerView
                           {
                               ComputerList = computers,
                               ProductList = product,
                               TrademarkList = trademark,
                               CategoryList = category
                           };
            return computer;
        }
    }
}
