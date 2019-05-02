using System;
using GalaSoft.MvvmLight;

namespace ParkingApp.ViewModel {
    public class RegisterViewModel : ViewModelBase {
        public string HourlyPrice => State.Instance.HourlyPrice / 100 + " DKK";

        public string TotalPrice => State.Instance.CurrentParking != null
            ? Math.Floor(DateTime.Now.Subtract(State.Instance.CurrentParking.TimeRegistered).TotalMinutes * State.Instance.HourlyPrice / 60 / 100) + " DKK"
            : "0 DKK";

        public string TimeRegistered => State.Instance.CurrentParking != null
            ? (State.Instance.CurrentParking.TimeRegistered).ToString("G")
            : DateTime.Now.ToString("G");
    }
}
