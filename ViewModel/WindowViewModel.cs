using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using FilterBuilder.Helper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using FilterBuilder.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

        public WindowViewModel() {
            Title = "Item Filter Builder";
            CurrentFilter = new Filter();
            ExecuteChangeViewCommand(Enum.View.HOME);
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
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# System.Net.HTTP");
            try {
                var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.').Select(int.Parse).ToArray();
                var release = JsonConvert.DeserializeObject<List<Release>>(await httpClient.GetStringAsync("https://api.github.com/repos/oscelest/FilterBuilder/releases")).SingleOrDefault(x => {
                    if (x.Prerelease) return false;
                    var releaseVersion = x.TagName.Split('.').Select(int.Parse).ToArray();
                    return !(currentVersion[0] >= releaseVersion[0] && currentVersion[1] >= releaseVersion[1] && currentVersion[2] >= releaseVersion[2] && currentVersion[3] >= releaseVersion[3]);
                });
                if (release == null) return;
                Debug.WriteLine($"Should update from {Assembly.GetExecutingAssembly().GetName().Version.ToString()} to {release.TagName}");
                new WebClient().DownloadFile(release.Assets[0].BrowserDownloadUrl, Path.Combine(Path.GetTempPath(), "release.zip"));
                Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "Updater", "FilterBuilderUpdater.exe"), $"{Process.GetCurrentProcess().Id} {release.Assets[0].BrowserDownloadUrl}");
            }
            catch (Exception e) {
                Debug.WriteLine(e);
            }
        }
    }
}