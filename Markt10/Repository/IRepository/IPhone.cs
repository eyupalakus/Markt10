using Markt10.ViewModel.HomeViewModel;

namespace Markt10.Repository.IRepository
{
    public interface IPhone
    {
        IEnumerable<PhoneView> GetAll();
        IEnumerable<PhoneView> Search(string search);
        IEnumerable<PhoneView> GetByPrice(int min, int max);
        IEnumerable<PhoneView> GetById(int id);
        IEnumerable<PhoneView> Trademark_Filter(List<int> trademark_filter);
        IEnumerable<PhoneView> Color_Filter(List<int> color_filter);
    }
}
