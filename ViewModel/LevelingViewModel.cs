using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class LevelingViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Leveling Items";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/Leveling.png";
        public Enum.View Key { get; } = Enum.View.LEVELING;
    }
}