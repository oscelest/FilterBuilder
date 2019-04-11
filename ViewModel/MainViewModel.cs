using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using FilterBuilder.Interfaces;
using FilterBuilder.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FilterBuilder.ViewModel {
    public class MainViewModel : ViewModelBase {
        public ViewModelBase CurrentViewModel { get; set; }
        public Filter CurrentFilter { get; set; }
        public string Title { get; set; }

        public ICommand ChangeViewCommand { get; }
        public ICommand OpenFilterCommand { get; }
        public ICommand SaveFilterCommand { get; }
        public ICommand LoadFilterCommand { get; }

        public static Dictionary<Enum.View, ViewModelBase> ViewModels { get; } = new Dictionary<Enum.View, ViewModelBase>() {
            {Enum.View.HOME, new HomeViewModel()},
            {Enum.View.CURRENCY, new CurrencyViewModel()},
            {Enum.View.UNIQUE_WEAPON, new UniqueWeaponViewModel()},
            {Enum.View.UNIQUE_ARMOUR, new UniqueArmourViewModel()},
            {Enum.View.UNIQUE_ACCESSORY, new UniqueAccessoryViewModel()},
            {Enum.View.DIVINATION_CARD, new DivinationCardViewModel()},
            {Enum.View.MAP, new MapViewModel()},
            {Enum.View.FRAGMENT, new FragmentViewModel()},
            {Enum.View.FOSSIL, new FossilViewModel()},
            {Enum.View.ESSENCE, new EssenceViewModel()},
            {Enum.View.VENDOR_RECIPE, new VendorRecipeViewModel()},
            {Enum.View.SKILL_GEM, new SkillGemViewModel()},
            {Enum.View.FLASK, new FlaskViewModel()},
            {Enum.View.CHANCE_BASE, new ChanceBaseViewModel()},
            {Enum.View.CRAFTING_BASE, new CraftingBaseViewModel()},
            {Enum.View.LEVELING, new LevelingViewModel()},
        };

        public MainViewModel() {
            Title = "Item Filter Builder";
            CurrentFilter = new Filter();
            ExecuteChangeViewCommand(Enum.View.HOME);
            ChangeViewCommand = new RelayCommand<Enum.View>(ExecuteChangeViewCommand);
            OpenFilterCommand = new RelayCommand(ExecuteOpenFilterCommand);
            SaveFilterCommand = new RelayCommand(ExecuteSaveFilterCommand);
            LoadFilterCommand = new RelayCommand(ExecuteLoadFilterCommand);
        }

        private void ExecuteNewFilterCommand() {
            CurrentFilter = new Filter();
            RaisePropertyChanged($"Filter");
        }

        private void ExecuteOpenFilterCommand() {
            var fileDialog = new Microsoft.Win32.OpenFileDialog {
                Filter = "filter files (*.filter)|*.filter",
                InitialDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "My Games", "Path of Exile")
            };

            if (fileDialog.ShowDialog() != true) return;
            CurrentFilter.Name = Path.GetFileName(fileDialog.FileName);
            CurrentFilter.Path = Path.GetDirectoryName(fileDialog.FileName);
            RaisePropertyChanged($"Filter");
        }

        private void ExecuteSaveFilterCommand() {
//            Filter.Filter.SaveFile(Path.Combine(FilterPath, FilterName));
        }

        private void ExecuteLoadFilterCommand() {
            // Filter.Filter.LoadFile(fileDialog.FileName);
            Title = $"Filter Builder - {CurrentFilter.Name}";
            RaisePropertyChanged($"Title");
            RaisePropertyChanged($"Filter");
        }

        private void ExecuteChangeViewCommand(Enum.View p) {
            CurrentViewModel = ViewModels[p];
            RaisePropertyChanged($"CurrentViewModel");
        }
    }
}