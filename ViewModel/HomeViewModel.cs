using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using ParkingApp.Helper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkingApp.Classes;
using ParkingApp.Enum;
using Keyboard = ParkingApp.Helper.Keyboard;

namespace ParkingApp.ViewModel {
    public class HomeViewModel : ViewModelBase {
        public Keyboard Keyboard { get; set; }
        public ICommand LicensePlateLookupCommand { get; }

        public string LicensePlate {
            get { return State.Instance.LicensePlate; }
            set {
                if (value == State.Instance.LicensePlate) return;
                State.Instance.LicensePlate = value;
                RaisePropertyChanged("LicensePlate");
            }
        }
        
        public Country Country {
            get { return State.Instance.CurrentCountry; }
            set {
                if (value == State.Instance.CurrentCountry) return;
                State.Instance.CurrentCountry = value;
                RaisePropertyChanged("Country");
            }
        }

        public HomeViewModel() {
            LicensePlateLookupCommand = new RelayCommand(ExecuteLicensePlateLookupCommand, ExecuteLicensePlateLookupCondition);
            Keyboard = new Keyboard()
                .PushRow(new List<char> {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'}, KeyboardWriteLetter)
                .PushRow(new List<char> {'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'}, KeyboardWriteLetter)
                .PushRow(new List<char> {'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'}, KeyboardWriteLetter)
                .PushRow(new List<char> {'Z', 'X', 'C', 'V', 'B', 'N', 'M'}, KeyboardWriteLetter)
                .PushKey(3, '⌫', new KeyboardKeyStyle {Width = 1.5}, KeyboardDeleteLetter)
                .UnshiftKey(3, '⌧', new KeyboardKeyStyle {Width = 1.5}, KeyboardDeleteAll);
        }

        private void KeyboardWriteLetter(char letter) {
            if (LicensePlate.Length >= 10) return;
            LicensePlate += letter;
        }

        private void KeyboardDeleteLetter(char letter) {
            // TODO: Should check for length
            if (LicensePlate.Length == 0) return;
            LicensePlate = LicensePlate.Remove(LicensePlate.Length - 1);
        }

        private void KeyboardDeleteAll(char letter) {
            LicensePlate = "";
        }

        public void ExecuteLicensePlateLookupCommand() {
            try {
                State.Instance.AvailableParkings = Parking.GetByLicensePlate(Country, LicensePlate);
                State.Instance.CurrentParking = State.Instance.AvailableParkings.Values.FirstOrDefault(x => x.TimeCompleted == null);
            }
            catch (Exception e) {
                Debug.WriteLine(e);
            }

            State.Instance.Locator.Window.ChangeViewCommand.Execute(Enum.View.REGISTER);
        }

        public bool ExecuteLicensePlateLookupCondition() {
            return LicensePlate.Length == 7;
        }
    }
}
