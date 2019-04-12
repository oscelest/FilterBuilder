using FilterBuilder.ViewModel;

namespace FilterBuilder.Service {
    public class LocatorService {
        private static WindowViewModel _main;

        public LocatorService() {
            _main = new WindowViewModel();
        }

        public WindowViewModel Main => _main;
    }
}
