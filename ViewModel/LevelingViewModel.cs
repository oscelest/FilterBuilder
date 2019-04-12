using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class LevelingViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Leveling Items";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/Leveling.png";
        public Enum.View Key { get; } = Enum.View.LEVELING;
    }
}