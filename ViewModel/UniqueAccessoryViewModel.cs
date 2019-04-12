using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class UniqueAccessoryViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Unique Accessories";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/UniqueAccessory.png";
        public Enum.View Key { get; } = Enum.View.UNIQUE_ACCESSORY;
    }
}