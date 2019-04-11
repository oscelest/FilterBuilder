using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class FragmentViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Fragments";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/Fragment.png";
        public Enum.View Key { get; } = Enum.View.FRAGMENT;
    }
}