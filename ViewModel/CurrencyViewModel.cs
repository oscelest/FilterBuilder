﻿using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class CurrencyViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Currency";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/Currency.png";
        public Enum.View Key { get; } = Enum.View.CURRENCY;
    }
}