using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class FossilViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Fossils";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/Fossil.png";
        public Enum.View Key { get; } = Enum.View.FOSSIL;
    }
}