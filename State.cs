using System;
using System.Collections.Generic;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using ParkingApp.Enum;
using ParkingApp.Helper;
using ParkingApp.Classes;
using ParkingApp.ViewModel;

namespace ParkingApp {
    public sealed class State {
        private static readonly Lazy<State> LazySingleton = new Lazy<State>(() => new State());

        public Parking CurrentParking { get; set; }
        public Dictionary<string, Parking> AvailableParkings { get; set; }
        public Translator CurrentLanguage { get; set; }
        public Dictionary<Language, Translator> AvailableLanguages { get; }
        public Country CurrentCountry { get; set; }
        public Dictionary<Language, Country> AvailableCountries { get; }
        public ViewModelBase CurrentViewModel { get; set; }
        public Dictionary<Enum.View, ViewModelBase> AvailableViewModels { get; }
        public LocatorService Locator => LocatorService.Instance;
        public string LicensePlate { get; set; }
        public int HourlyPrice { get; }

        private State() {
            AvailableLanguages = new Dictionary<Language, Translator> {
                {Language.DANISH, new Translator(Language.DANISH, "Danish")},
                {Language.ENGLISH, new Translator(Language.ENGLISH, "English")},
            };
            AvailableViewModels = new Dictionary<Enum.View, ViewModelBase> {
                {Enum.View.HOME, Locator.Home},
                {Enum.View.REGISTER, Locator.Register},
                {Enum.View.COMPLETE, Locator.Complete},
                {Enum.View.PAYMENT, Locator.Payment}
            };
            AvailableCountries = new Dictionary<Language, Country> {
                {Language.DANISH, Enum.Country.DENMARK},
                {Language.ENGLISH, Enum.Country.GREAT_BRITAIN},
            };
            CurrentLanguage = AvailableLanguages[Language.DANISH];
            CurrentViewModel = AvailableViewModels[Enum.View.HOME];
            LicensePlate = "AA11111";
            CurrentCountry = Country.DENMARK;
            HourlyPrice = 949;
        }

        public static State Instance => LazySingleton.Value;

        public sealed class LocatorService {
            private static readonly Lazy<LocatorService> LazySingleton = new Lazy<LocatorService>(() => new LocatorService());

            public WindowViewModel Window => _window;
            public HomeViewModel Home => _home;
            public RegisterViewModel Register => _register;
            public CompleteViewModel Complete => _complete;
            public PaymentViewModel Payment => _payment;

            private LocatorService() {
                _home = new HomeViewModel();
                _window = new WindowViewModel();
                _register = new RegisterViewModel();
                _payment = new PaymentViewModel();
                _complete = new CompleteViewModel();
            }

            public static LocatorService Instance => LazySingleton.Value;
            private static WindowViewModel _window;
            private static HomeViewModel _home;
            private static RegisterViewModel _register;
            private static CompleteViewModel _complete;
            private static PaymentViewModel _payment;
        }
    }
}
