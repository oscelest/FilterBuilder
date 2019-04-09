using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class UniqueWeaponViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Unique Weapons";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/UniqueWeapon.png";
        public Enum.View Key { get; } = Enum.View.UNIQUE_WEAPON;
    }
}