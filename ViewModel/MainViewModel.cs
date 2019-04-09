using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FilterBuilder.ViewModel {
    public class MainViewModel : ViewModelBase {
        private ViewModelBase _currentViewModel;

        private Dictionary<Enum.View, ViewModelBase> ViewModels { get; } = new Dictionary<Enum.View, ViewModelBase>() {
            {Enum.View.HOME, new HomeViewModel()},
            {Enum.View.CURRENCY, new CurrencyViewModel()},
            {Enum.View.UNIQUE_WEAPON, new UniqueWeaponViewModel()},
            {Enum.View.UNIQUE_ARMOUR, new UniqueArmourViewModel()},
            {Enum.View.UNIQUE_ACCESSORY, new UniqueAccessoryViewModel()},
            {Enum.View.DIVINATION_CARD, new DivinationCardViewModel()},
            {Enum.View.MAP, new MapViewModel()},
            {Enum.View.FRAGMENT, new FragmentViewModel()},
            {Enum.View.FOSSIL, new FossilViewModel()},
            {Enum.View.ESSENCE, new EssenceViewModel()},
            {Enum.View.VENDOR_RECIPE, new VendorRecipeViewModel()},
            {Enum.View.SKILL_GEM, new SkillGemViewModel()},
            {Enum.View.FLASK, new FlaskViewModel()},
            {Enum.View.CHANCE_BASE, new ChanceBaseViewModel()},
            {Enum.View.CRAFTING_BASE, new CraftingBaseViewModel()},
            {Enum.View.LEVELING, new LevelingViewModel()},
        };

        public Dictionary<Enum.View, INavigationViewModel> NavigationViewModels { get; } = new Dictionary<Enum.View, INavigationViewModel>() {
            {Enum.View.HOME, new HomeViewModel()},
            {Enum.View.CURRENCY, new CurrencyViewModel()},
            {Enum.View.UNIQUE_WEAPON, new UniqueWeaponViewModel()},
            {Enum.View.UNIQUE_ARMOUR, new UniqueArmourViewModel()},
            {Enum.View.UNIQUE_ACCESSORY, new UniqueAccessoryViewModel()},
            {Enum.View.DIVINATION_CARD, new DivinationCardViewModel()},
            {Enum.View.MAP, new MapViewModel()},
            {Enum.View.FRAGMENT, new FragmentViewModel()},
            {Enum.View.FOSSIL, new FossilViewModel()},
            {Enum.View.ESSENCE, new EssenceViewModel()},
            {Enum.View.VENDOR_RECIPE, new VendorRecipeViewModel()},
            {Enum.View.SKILL_GEM, new SkillGemViewModel()},
            {Enum.View.FLASK, new FlaskViewModel()},
            {Enum.View.CHANCE_BASE, new ChanceBaseViewModel()},
            {Enum.View.CRAFTING_BASE, new CraftingBaseViewModel()},
            {Enum.View.LEVELING, new LevelingViewModel()},
        };

        public ViewModelBase CurrentViewModel {
            get => _currentViewModel;
            set {
                if (_currentViewModel == value) return;
                _currentViewModel = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ChangeViewCommand { get; }

        public MainViewModel() {
            CurrentViewModel = ViewModels[Enum.View.HOME];
            ChangeViewCommand = new RelayCommand<Enum.View>(ExecuteChangeViewCommand);
        }

        private void ExecuteChangeViewCommand(Enum.View p) {
            CurrentViewModel = ViewModels[p];
        }
    }
}