using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class EssenceViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Essences";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/Essence.png";
        public Enum.View Key { get; } = Enum.View.ESSENCE;
    }
}