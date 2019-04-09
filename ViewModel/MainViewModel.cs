using System.Collections.Generic;
using System.Windows.Input;
using FilterBuilder.Enum;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FilterBuilder.ViewModel {
    public class MainViewModel : ViewModelBase {
        private ViewModelBase _currentViewModel;

        private readonly Dictionary<Page, ViewModelBase> _viewModels = new Dictionary<Page, ViewModelBase>() {
            {Page.HOME, new HomeViewModel()},
            {Page.UNIQUES, new UniqueViewModel()},
        };

        public ViewModelBase CurrentViewModel {
            get => _currentViewModel;
            set {
                if (_currentViewModel == value) return;
                _currentViewModel = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ChangeViewCommand { get; }

        public MainViewModel() {
            CurrentViewModel = _viewModels[Page.HOME];
            ChangeViewCommand = new RelayCommand<Page>(ExecuteChangeViewCommand);
        }

        private void ExecuteChangeViewCommand(Page p) {
            CurrentViewModel = _viewModels[p];
        }
    }
}