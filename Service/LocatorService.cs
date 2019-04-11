using FilterBuilder.ViewModel;

namespace FilterBuilder.Service {
    public class LocatorService {
        private static MainViewModel _main;

        public LocatorService() {
            _main = new MainViewModel();
        }

        public MainViewModel Main => _main;
    }
}
