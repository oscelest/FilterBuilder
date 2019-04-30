using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using ParkingApp.Enum;
using ParkingApp.Helper;
using ParkingApp.Classes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;

namespace ParkingApp.ViewModel {
    public class WindowViewModel : ViewModelBase {
        public string Title { get; set; }
        public ICommand ChangeViewCommand { get; }
        public ICommand ChangeLanguageCommand { get; }

        public ViewModelBase CurrentViewModel {
            get { return State.Instance.CurrentViewModel; }
            set {
                if (value == State.Instance.CurrentViewModel) return;
                State.Instance.CurrentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        public Translator CurrentLanguage {
            get { return State.Instance.CurrentLanguage; }
            set {
                if (value == State.Instance.CurrentLanguage) return;
                State.Instance.CurrentLanguage = value;
                RaisePropertyChanged("CurrentLanguage");
            }
        }

        public List<Translator> AvailableLanguages {
            get {
                return State.Instance.AvailableLanguages.Select(kvp => kvp.Value).ToList();
            }
        }

        public WindowViewModel() {
            Title = "Item Filter Builder";
            ChangeViewCommand = new RelayCommand<Enum.View>(ExecuteChangeViewCommand);
            ChangeLanguageCommand = new RelayCommand<Language>(ExecuteChangeLanguageCommand);
            ExecuteCheckUpdateCommand();
        }

        private void ExecuteChangeViewCommand(Enum.View p) {
            CurrentViewModel = State.Instance.AvailableViewModels[p];
        }

        private void ExecuteChangeLanguageCommand(Language p) {
            Debug.WriteLine(p);
            CurrentLanguage = State.Instance.AvailableLanguages[p];
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
