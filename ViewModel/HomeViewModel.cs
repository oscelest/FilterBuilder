using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class HomeViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Home";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/Home.png";
        public Enum.View Key { get; } = Enum.View.HOME;

        public HomeViewModel() { }
    }
}