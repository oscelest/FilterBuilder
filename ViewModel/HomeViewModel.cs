using System.Collections.Generic;
using ParkingApp.Helper;
using GalaSoft.MvvmLight;
using Keyboard = ParkingApp.Helper.Keyboard;

namespace ParkingApp.ViewModel {
    public class HomeViewModel : ViewModelBase {
        public string LicensePlate {
            get { return State.Instance.LicensePlate; }
            set {
                if (value == State.Instance.LicensePlate) return;
                State.Instance.LicensePlate = value;
                RaisePropertyChanged("LicensePlate");
            }
        }

        public Keyboard Keyboard { get; set; }

        public HomeViewModel() {
            Keyboard = new Keyboard()
                .PushRow(new List<char> {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'}, KeyboardWriteLetter)
                .PushRow(new List<char> {'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'}, KeyboardWriteLetter)
                .PushRow(new List<char> {'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'}, KeyboardWriteLetter)
                .PushRow(new List<char> {'Z', 'X', 'C', 'V', 'B', 'N', 'M'}, KeyboardWriteLetter)
                .PushKey(3, '⌫', new KeyboardKeyStyle{Width = 1.5}, KeyboardDeleteLetter)
                .UnshiftKey(3, '⌧', new KeyboardKeyStyle{Width = 1.5}, KeyboardDeleteAll);
        }

        private void KeyboardWriteLetter(char letter) {
            if (LicensePlate.Length >= 10) return;
            LicensePlate += letter;
            RaisePropertyChanged("LicensePlate");
        }

        private void KeyboardDeleteLetter(char letter) {
            // TODO: Should check for length
            if (LicensePlate.Length == 0) return;
            LicensePlate = LicensePlate.Remove(LicensePlate.Length - 1);
            RaisePropertyChanged("LicensePlate");
        }

        private void KeyboardDeleteAll(char letter) {
            LicensePlate = "";
            RaisePropertyChanged("LicensePlate");
        }
    }
}
