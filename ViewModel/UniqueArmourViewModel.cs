﻿using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class UniqueArmourViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Unique Armours";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/UniqueArmour.png";
        public Enum.View Key { get; } = Enum.View.UNIQUE_ARMOUR;
    }
}