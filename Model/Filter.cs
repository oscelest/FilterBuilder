using System.Collections.Generic;
using FilterBuilder.Interface;
using FilterBuilder.ViewModel;

namespace FilterBuilder.Model {
    public class Filter {
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public bool UnsavedChanges { get; set; } = false;

        public Dictionary<Enum.View, INavigationViewModel> NavigationViewModels { get; } = new Dictionary<Enum.View, INavigationViewModel>() {
            {Enum.View.HOME, WindowViewModel.ViewModels[Enum.View.HOME] as INavigationViewModel},
            {Enum.View.CURRENCY, WindowViewModel.ViewModels[Enum.View.CURRENCY] as INavigationViewModel},
            {Enum.View.UNIQUE_WEAPON, WindowViewModel.ViewModels[Enum.View.UNIQUE_WEAPON] as INavigationViewModel},
            {Enum.View.UNIQUE_ARMOUR, WindowViewModel.ViewModels[Enum.View.UNIQUE_WEAPON] as INavigationViewModel},
            {Enum.View.UNIQUE_ACCESSORY, WindowViewModel.ViewModels[Enum.View.UNIQUE_ACCESSORY] as INavigationViewModel},
            {Enum.View.DIVINATION_CARD, WindowViewModel.ViewModels[Enum.View.DIVINATION_CARD] as INavigationViewModel},
            {Enum.View.MAP, WindowViewModel.ViewModels[Enum.View.MAP] as INavigationViewModel},
            {Enum.View.FRAGMENT, WindowViewModel.ViewModels[Enum.View.FRAGMENT] as INavigationViewModel},
            {Enum.View.FOSSIL, WindowViewModel.ViewModels[Enum.View.FOSSIL] as INavigationViewModel},
            {Enum.View.ESSENCE, WindowViewModel.ViewModels[Enum.View.ESSENCE] as INavigationViewModel},
            {Enum.View.VENDOR_RECIPE, WindowViewModel.ViewModels[Enum.View.VENDOR_RECIPE] as INavigationViewModel},
            {Enum.View.SKILL_GEM, WindowViewModel.ViewModels[Enum.View.SKILL_GEM] as INavigationViewModel},
            {Enum.View.FLASK, WindowViewModel.ViewModels[Enum.View.FLASK] as INavigationViewModel},
            {Enum.View.CHANCE_BASE, WindowViewModel.ViewModels[Enum.View.CHANCE_BASE] as INavigationViewModel},
            {Enum.View.CRAFTING_BASE, WindowViewModel.ViewModels[Enum.View.CRAFTING_BASE] as INavigationViewModel},
            {Enum.View.LEVELING, WindowViewModel.ViewModels[Enum.View.LEVELING] as INavigationViewModel},
        };

        public Filter() { }
    }
}