using ParkingApp.ViewModel;

namespace ParkingApp.Service {
    public class LocatorService {
        private static WindowViewModel _window;
        private static HomeViewModel _home;
        private static RegisterViewModel _register;
        private static CompleteViewModel _complete;
        private static PaymentViewModel _payment;

        public LocatorService() {
            _window = new WindowViewModel();
            _home = new HomeViewModel();
            _register = new RegisterViewModel();
            _complete = new CompleteViewModel();
            _payment = new PaymentViewModel();
        }

        public WindowViewModel Window => _window;
        public HomeViewModel Home => _home;
        public RegisterViewModel Register => _register;
        public CompleteViewModel Complete => _complete;
        public PaymentViewModel Payment => _payment;
    }
}
