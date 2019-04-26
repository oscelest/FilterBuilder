using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Keyboard = FilterBuilder.Helper.Keyboard;

namespace FilterBuilder.ViewModel {
    public class HomeViewModel : ViewModelBase {
        public string LicensePlate {
            get { return State.Instance.LicensePlate; }
            set {
                if (value == State.Instance.LicensePlate) return;
                State.Instance.LicensePlate = value;
                RaisePropertyChanged("LicensePlate");
            }
        }

        public Keyboard Keyboard {
            get { return State.Instance.Keyboard; }
            set {
                if (value == State.Instance.Keyboard) return;
                State.Instance.Keyboard = value;
                RaisePropertyChanged("Keyboard");
            }
        }

        public ICommand KeyboardWriteLetterCommand { get; }
        public ICommand KeyboardDeleteLetterCommand { get; }
        public ICommand KeyboardDeleteAllCommand { get; }

        public HomeViewModel() {
            KeyboardWriteLetterCommand = new RelayCommand<string>(ExecuteKeyboardWriteLetterCommand);
            KeyboardDeleteLetterCommand = new RelayCommand(ExecuteKeyboardDeleteLetterCommand);
            KeyboardDeleteAllCommand = new RelayCommand(ExecuteKeyboardDeleteAllCommand);
        }

        private void ExecuteKeyboardWriteLetterCommand(string letter) {
            LicensePlate += letter;
            RaisePropertyChanged("LicensePlate");
        }

        private void ExecuteKeyboardDeleteLetterCommand() {
            // TODO: Should check for length
            if (LicensePlate.Length == 0) return;
            LicensePlate = LicensePlate.Remove(State.Instance.LicensePlate.Length - 1, 1);
            RaisePropertyChanged("LicensePlate");
        }

        private void ExecuteKeyboardDeleteAllCommand() {
            LicensePlate = "";
            RaisePropertyChanged("LicensePlate");
        }
    }
}
