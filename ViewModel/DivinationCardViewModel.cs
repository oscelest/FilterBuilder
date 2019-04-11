using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class DivinationCardViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Divination Cards";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/DivinationCard.png";
        public Enum.View Key { get; } = Enum.View.UNIQUE_WEAPON;
    }
}