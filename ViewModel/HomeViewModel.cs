using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FilterBuilder.ViewModel {
    public class HomeViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Home";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/Home.png";
        public Enum.View Key { get; } = Enum.View.HOME;

        public HomeViewModel() { }
    }
}