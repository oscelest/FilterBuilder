using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class ChanceBaseViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Chance Bases";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/ChanceBase.png";
        public Enum.View Key { get; } = Enum.View.CHANCE_BASE;
    }
}