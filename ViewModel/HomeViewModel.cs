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
        
        public HomeViewModel() {
            ShowPopUp = new RelayCommand(ShowPopUpExecute, () => true);
            IncrementValue = new RelayCommand(IncrementValueExecute, () => true);
            ExampleValue = 0;
        }

        private ICommand ShowPopUp { get; set; }

        private ICommand IncrementValue { get; set; }

        private static void ShowPopUpExecute() {
            MessageBox.Show("Hello World!");
        }

        private void IncrementValueExecute() {
            ExampleValue += 1;
        }

        private int _exampleValue;

        private int ExampleValue {
            get { return _exampleValue; }
            set {
                if (_exampleValue == value)
                    return;
                _exampleValue = value;
                RaisePropertyChanged("ExampleValue");
            }
        }
    }
}