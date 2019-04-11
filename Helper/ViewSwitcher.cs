using FilterBuilder.Views;

namespace FilterBuilder.Helper {
    public class ViewSwitcher : BindableBase {
        public ViewSwitcher() {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private Editor _editorViewModel = new Editor();
        private Startup _startupViewModel = new Startup();
        public BindableBase CurrentViewModel;

//        public BindableBase CurrentViewModel {
//            get { return _currentViewModel; }
//            set { SetProperty(ref _currentViewModel, value); }
//        }

        public MyICommand<string> NavCommand { get; private set; }

        private void OnNav(string destination) {
            switch (destination) {
                case "editor":
                    CurrentViewModel = _editorViewModel;
                    break;
                case "startup":
                default:
                    CurrentViewModel = _startupViewModel;
                    break;
            }
        }
    }
}