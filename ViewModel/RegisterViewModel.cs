using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkingApp.Classes;

namespace ParkingApp.ViewModel {
    public class RegisterViewModel : ViewModelBase {
        public ICommand RegisterParkingCommand { get; }
        public ICommand CompleteParkingCommand { get; }
        public string HourlyPrice => State.Instance.HourlyPrice / 100 + " DKK";

        public Parking CurrentParking {
            get { return State.Instance.CurrentParking; }
            set {
                if (value == State.Instance.CurrentParking) return;
                State.Instance.CurrentParking = value;
                RaisePropertyChanged("CurrentParking");
            }
        }

        public string TotalPrice => State.Instance.CurrentParking != null
            ? Math.Floor(DateTime.Now.Subtract(State.Instance.CurrentParking.TimeRegistered).TotalMinutes * State.Instance.HourlyPrice / 60 / 100) + " DKK"
            : "0 DKK";

        public string TimeRegistered => State.Instance.CurrentParking != null
            ? (State.Instance.CurrentParking.TimeRegistered).ToString("G")
            : DateTime.Now.ToString("G");

        public RegisterViewModel() {
            RegisterParkingCommand = new RelayCommand(ExecuteRegisterParkingCommand);
            CompleteParkingCommand = new RelayCommand(ExecuteCompleteParkingCommand);
        }

        public void ExecuteRegisterParkingCommand() {
            Parking.Post(State.Instance.CurrentCountry, State.Instance.LicensePlate);
            CurrentParking = State.Instance.AvailableParkings.Values.FirstOrDefault(x => x.TimeCompleted == null);
            State.Instance.Locator.Window.ChangeViewCommand.Execute(Enum.View.COMPLETE);
        }

        public void ExecuteCompleteParkingCommand() {
            Parking.Put(State.Instance.CurrentCountry, State.Instance.LicensePlate);
//            State.Instance.Locator.Window.ChangeViewCommand.Execute(Enum.View.PAYMENT);
//            Console.WriteLine("Please put in your credit card.");
//            Parking.Test();
            CurrentParking = null;
            State.Instance.Locator.Window.ChangeViewCommand.Execute(Enum.View.COMPLETE);
        }
    }
}
