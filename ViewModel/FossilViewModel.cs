using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class FossilViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Fossils";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/Fossil.png";
        public Enum.View Key { get; } = Enum.View.FOSSIL;
    }
}