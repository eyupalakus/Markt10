using Markt10.Models;
using Markt10.ViewModel.HomeViewModel;

namespace Markt10.ViewModel.HomeView
{
    public class HomeViewModel
    {
        public List<TvView>  TvView { get; set; }
        public List<AccessoryView>  AccessoryView { get; set; }
        public List<ComputerView>  ComputerView { get; set; }
        public List<PhoneView>  PhoneView { get; set; }
        public List<HousefoldView> HousefoldView { get; set; }
        public List<Trademark> Trademark { get; set; }
        public List<Color> Color { get; set; }
        public List<Category> Category { get; set; }
        public List<Product> Product { get; set; }
    }
}
