using Markt10.ViewModel.HomeViewModel;

namespace Markt10.Repository.IRepository
{
    public interface ITv
    {
        IEnumerable<TvView> GetAll();
        IEnumerable<TvView> Search(string search);
        IEnumerable<TvView> GetByPrice(int min, int max);
        IEnumerable<TvView> GetById(int id);
        IEnumerable<TvView> Trademark_Filter(List<int> trademark_filter);
        IEnumerable<TvView> Color_Filter(List<int> color_filter);
    }
}
