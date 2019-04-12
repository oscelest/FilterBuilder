using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class VendorRecipeViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Vendor Recipes";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/VendorRecipe.png";
        public Enum.View Key { get; } = Enum.View.VENDOR_RECIPE;
    }
}