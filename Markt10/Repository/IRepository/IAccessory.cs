using Markt10.ViewModel.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.DataAccess.Repository.IRepository
{
    public interface IAccessory
    {
        IEnumerable<AccessoryView> GetAll();
        IEnumerable<AccessoryView> Search(string search);
        IEnumerable<AccessoryView> GetByPrice(int min, int max);
        IEnumerable<AccessoryView> GetById(int id);
        IEnumerable<AccessoryView> Trademark_Filter(List<int> trademark_filter);
        IEnumerable<AccessoryView> Color_Filter(List<int> color_filter);

    }
}
