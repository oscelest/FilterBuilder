using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using FilterBuilder.Helper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using FilterBuilder.Model;
using FilterBuilder.ViewModel;
using Newtonsoft.Json;

namespace FilterBuilder.ViewModel {
    public class WindowViewModel : ViewModelBase {
        public ViewModelBase CurrentViewModel { get; set; }
        public Filter CurrentFilter { get; set; }
        public string Title { get; set; }

        public ICommand ChangeViewCommand { get; }
        public ICommand OpenFilterCommand { get; }
        public ICommand SaveFilterCommand { get; }
        public ICommand LoadFilterCommand { get; }

        public static Dictionary<FilterBuilder.Enum.View, ViewModelBase> ViewModels { get; } = new Dictionary<FilterBuilder.Enum.View, ViewModelBase>() {
            {FilterBuilder.Enum.View.HOME, new HomeViewModel()},
            {FilterBuilder.Enum.View.CURRENCY, new CurrencyViewModel()},
            {FilterBuilder.Enum.View.UNIQUE_WEAPON, new UniqueWeaponViewModel()},
            {FilterBuilder.Enum.View.UNIQUE_ARMOUR, new UniqueArmourViewModel()},
            {FilterBuilder.Enum.View.UNIQUE_ACCESSORY, new UniqueAccessoryViewModel()},
            {FilterBuilder.Enum.View.DIVINATION_CARD, new DivinationCardViewModel()},
            {FilterBuilder.Enum.View.MAP, new MapViewModel()},
            {FilterBuilder.Enum.View.FRAGMENT, new FragmentViewModel()},
            {FilterBuilder.Enum.View.FOSSIL, new FossilViewModel()},
            {FilterBuilder.Enum.View.ESSENCE, new EssenceViewModel()},
            {FilterBuilder.Enum.View.VENDOR_RECIPE, new VendorRecipeViewModel()},
            {FilterBuilder.Enum.View.SKILL_GEM, new SkillGemViewModel()},
            {FilterBuilder.Enum.View.FLASK, new FlaskViewModel()},
            {FilterBuilder.Enum.View.CHANCE_BASE, new ChanceBaseViewModel()},
            {FilterBuilder.Enum.View.CRAFTING_BASE, new CraftingBaseViewModel()},
            {FilterBuilder.Enum.View.LEVELING, new LevelingViewModel()},
        };

        public WindowViewModel() {
            Title = "Item Filter Builder";
            CurrentFilter = new Filter();
            ExecuteChangeViewCommand(FilterBuilder.Enum.View.HOME);
            ExecuteCheckUpdateCommand();
            ChangeViewCommand = new RelayCommand<FilterBuilder.Enum.View>(ExecuteChangeViewCommand);
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
            RaisePropertyChanged($"CurrentFilter");
        }

        private void ExecuteSaveFilterCommand() {
//            Filter.Filter.SaveFile(Path.Combine(FilterPath, FilterName));
        }

        private void ExecuteLoadFilterCommand() {
            // Filter.Filter.LoadFile(fileDialog.FileName);
            if (!File.Exists(Path.Combine(CurrentFilter.Path, CurrentFilter.Name))) {
                MessageBox.Show("File could not be loaded.");
                return;
            }

            Title = $"Filter Builder - {CurrentFilter.Name}";
            RaisePropertyChanged($"Title");
            RaisePropertyChanged($"CurrentFilter");
        }

        private void ExecuteChangeViewCommand(FilterBuilder.Enum.View p) {
            CurrentViewModel = ViewModels[p];
            RaisePropertyChanged($"CurrentViewModel");
        }

        private async void ExecuteCheckUpdateCommand() {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# System.Net.HTTP");
            try {
                var release = JsonConvert.DeserializeObject<List<Release>>(await client.GetStringAsync("https://api.github.com/repos/oscelest/FilterBuilder/releases"));
                if (release.Count == 0) return;
                var current_version = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.').Select(x => int.Parse(x)).ToArray();
                var release_version = release[0].TagName.Split('.').Select(x => int.Parse(x)).ToArray();
                Debug.WriteLine(current_version);
                Debug.WriteLine(release_version);
                if (current_version[0] >= release_version[0] && current_version[1] >= release_version[1] && current_version[2] >= release_version[2] &&
                    current_version[3] >= release_version[3]) return;
            }
            catch (Exception e) {
                Debug.WriteLine(e);
            }
        }
    }
}