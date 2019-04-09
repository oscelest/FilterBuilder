using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FilterBuilder.ViewModel {
    public class HomeViewModel : ViewModelBase {
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