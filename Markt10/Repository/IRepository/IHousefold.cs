using Markt10.ViewModel.HomeViewModel;

namespace Markt10.Repository.IRepository
{
    public interface IHousefold
    {
        IEnumerable<HousefoldView> GetAll();
        IEnumerable<HousefoldView> Search(string search);
        IEnumerable<HousefoldView> GetByPrice(int min, int max);
        IEnumerable<HousefoldView> GetById(int id);
        IEnumerable<HousefoldView> Trademark_Filter(List<int> trademark_filter);
        IEnumerable<HousefoldView> Color_Filter(List<int> color_filter);
    }
}
