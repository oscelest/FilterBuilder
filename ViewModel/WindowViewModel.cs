using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Windows.Input;
using ParkingApp.Enum;
using ParkingApp.Helper;
using ParkingApp.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;

namespace ParkingApp.ViewModel {
    public class WindowViewModel : ViewModelBase {
        public WindowViewModel() {
            Title = "Item Filter Builder";
            ChangeViewCommand = new RelayCommand<Enum.View>(ExecuteChangeViewCommand);
            ChangeLanguageCommand = new RelayCommand<Language>(ExecuteChangeLanguageCommand);
            ExecuteChangeViewCommand(Enum.View.HOME);
            ExecuteCheckUpdateCommand();
        }

        public string Title { get; set; }
        public ViewModelBase CurrentViewModel { get; set; }
        public ICommand ChangeViewCommand { get; }
        public ICommand ChangeLanguageCommand { get; }

        public static Dictionary<Enum.View, ViewModelBase> ViewModels { get; } = new Dictionary<Enum.View, ViewModelBase> {
            {Enum.View.HOME, new HomeViewModel()},
            {Enum.View.REGISTER, new RegisterViewModel()},
            {Enum.View.COMPLETE, new CompleteViewModel()},
            {Enum.View.PAYMENT, new PaymentViewModel()}
        };

        private void ExecuteChangeViewCommand(Enum.View p) {
            CurrentViewModel = ViewModels[p];
            RaisePropertyChanged("CurrentViewModel");
        }

        private void ExecuteChangeLanguageCommand(Language p) {
            State.Instance.CurrentLanguage = State.Instance.AvailableLanguages.SingleOrDefault(v => v.Id == p);
            RaisePropertyChanged("ChangeLanguageCommand");
        }

        private async void ExecuteCheckUpdateCommand() {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# System.Net.HTTP");
            try {
                var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.').Select(int.Parse).ToArray();
                var release = JsonConvert.DeserializeObject<List<Release>>(await httpClient.GetStringAsync("https://api.github.com/repos/oscelest/ParkingApp/releases")).SingleOrDefault(x => {
                    if (x.Prerelease) return false;
                    var releaseVersion = x.TagName.Split('.').Select(int.Parse).ToArray();
                    return !(currentVersion[0] >= releaseVersion[0] && currentVersion[1] >= releaseVersion[1] && currentVersion[2] >= releaseVersion[2] && currentVersion[3] >= releaseVersion[3]);
                });
                if (release == null) return;
                new WebClient().DownloadFile(release.Assets[0].BrowserDownloadUrl, Path.Combine(Path.GetTempPath(), "release.zip"));
                Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "Updater", "ParkingAppUpdater.exe"), $"{Process.GetCurrentProcess().Id} {release.Assets[0].BrowserDownloadUrl}");
            }
            catch (Exception e) {
                Debug.WriteLine(e);
            }
        }
    }
}
