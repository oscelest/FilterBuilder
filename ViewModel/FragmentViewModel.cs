using GalaSoft.MvvmLight;
using FilterBuilder.Interface;

namespace FilterBuilder.ViewModel {
    public class FragmentViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Fragments";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/Fragment.png";
        public Enum.View Key { get; } = Enum.View.FRAGMENT;
    }
}