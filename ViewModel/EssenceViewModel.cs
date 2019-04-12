using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class EssenceViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Essences";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/Essence.png";
        public Enum.View Key { get; } = Enum.View.ESSENCE;
    }
}