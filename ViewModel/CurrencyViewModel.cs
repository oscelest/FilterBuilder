using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class CurrencyViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Currency";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/Currency.png";
        public Enum.View Key { get; } = Enum.View.CURRENCY;
    }
}