using System;
using System.Collections.Generic;
using System.Windows;
using FilterBuilder.Interfaces;
using FilterBuilder.ViewModel;

namespace FilterBuilder.Model {
    public class Filter {
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public bool UnsavedChanges { get; set; } = false;

        public Dictionary<Enum.View, INavigationViewModel> NavigationViewModels { get; } = new Dictionary<Enum.View, INavigationViewModel>() {
            {Enum.View.HOME, MainViewModel.ViewModels[Enum.View.HOME] as INavigationViewModel},
            {Enum.View.CURRENCY, MainViewModel.ViewModels[Enum.View.CURRENCY] as INavigationViewModel},
            {Enum.View.UNIQUE_WEAPON, MainViewModel.ViewModels[Enum.View.UNIQUE_WEAPON] as INavigationViewModel},
            {Enum.View.UNIQUE_ARMOUR, MainViewModel.ViewModels[Enum.View.UNIQUE_WEAPON] as INavigationViewModel},
            {Enum.View.UNIQUE_ACCESSORY, MainViewModel.ViewModels[Enum.View.UNIQUE_ACCESSORY] as INavigationViewModel},
            {Enum.View.DIVINATION_CARD, MainViewModel.ViewModels[Enum.View.DIVINATION_CARD] as INavigationViewModel},
            {Enum.View.MAP, MainViewModel.ViewModels[Enum.View.MAP] as INavigationViewModel},
            {Enum.View.FRAGMENT, MainViewModel.ViewModels[Enum.View.FRAGMENT] as INavigationViewModel},
            {Enum.View.FOSSIL, MainViewModel.ViewModels[Enum.View.FOSSIL] as INavigationViewModel},
            {Enum.View.ESSENCE, MainViewModel.ViewModels[Enum.View.ESSENCE] as INavigationViewModel},
            {Enum.View.VENDOR_RECIPE, MainViewModel.ViewModels[Enum.View.VENDOR_RECIPE] as INavigationViewModel},
            {Enum.View.SKILL_GEM, MainViewModel.ViewModels[Enum.View.SKILL_GEM] as INavigationViewModel},
            {Enum.View.FLASK, MainViewModel.ViewModels[Enum.View.FLASK] as INavigationViewModel},
            {Enum.View.CHANCE_BASE, MainViewModel.ViewModels[Enum.View.CHANCE_BASE] as INavigationViewModel},
            {Enum.View.CRAFTING_BASE, MainViewModel.ViewModels[Enum.View.CRAFTING_BASE] as INavigationViewModel},
            {Enum.View.LEVELING, MainViewModel.ViewModels[Enum.View.LEVELING] as INavigationViewModel},
        };

        public Filter() { }
    }
}