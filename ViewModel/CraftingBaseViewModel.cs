using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class CraftingBaseViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Crafting Bases";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/CraftingBase.png";
        public Enum.View Key { get; } = Enum.View.CRAFTING_BASE;
    }
}