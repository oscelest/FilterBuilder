using System.Diagnostics;
using GalaSoft.MvvmLight;
using ParkingApp.Classes;

namespace ParkingApp.ViewModel {
    public class CompleteViewModel : ViewModelBase {
        
        public Parking CurrentParking {
            get {
                return State.Instance.CurrentParking;
            }
            set {
                if (value == State.Instance.CurrentParking) return;
                State.Instance.CurrentParking = value;
                RaisePropertyChanged("CurrentParking");
            }
        }
    }
}
