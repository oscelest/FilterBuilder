using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class UniqueArmourViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Unique Armours";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/UniqueArmour.png";
        public Enum.View Key { get; } = Enum.View.UNIQUE_ARMOUR;
    }
}