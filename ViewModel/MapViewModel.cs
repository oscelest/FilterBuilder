using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class MapViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Maps";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/Map.png";
        public Enum.View Key { get; } = Enum.View.MAP;
    }
}