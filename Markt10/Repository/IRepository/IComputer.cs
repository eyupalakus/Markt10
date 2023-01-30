using Markt10.ViewModel.HomeViewModel;

namespace Markt10.Repository.IRepository
{
    public interface IComputer
    {
        IEnumerable<ComputerView> GetAll();
        IEnumerable<ComputerView> Search(string search);
        IEnumerable<ComputerView> GetByPrice(int min, int max);
        IEnumerable<ComputerView> GetById(int id);
        IEnumerable<ComputerView> Trademark_Filter(List<int> trademark_filter);
        IEnumerable<ComputerView> Color_Filter(List<int> color_filter);
    }
}
