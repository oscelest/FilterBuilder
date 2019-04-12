using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class FlaskViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Flasks";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/Flask.png";
        public Enum.View Key { get; } = Enum.View.FLASK;
    }
}