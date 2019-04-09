using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class FlaskViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Flasks";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/Flask.png";
        public Enum.View Key { get; } = Enum.View.FLASK;
    }
}