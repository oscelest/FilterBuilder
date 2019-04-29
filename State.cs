using System;
using System.Collections.Generic;
using System.Diagnostics;
using ParkingApp.Enum;
using ParkingApp.Helper;
using ParkingApp.Service;

namespace ParkingApp {
    public class State {
        private static readonly Lazy<State> LazySingleton = new Lazy<State>(() => new State());

        public List<TranslatorService> AvailableLanguages { get; }
        public TranslatorService CurrentLanguage { get; set; }
        public string LicensePlate { get; set; }

        private State() {
            AvailableLanguages = new List<TranslatorService> {
                new TranslatorService(Language.DANISH, "Danish"),
                new TranslatorService(Language.ENGLISH, "English")
            };
            CurrentLanguage = AvailableLanguages[0];
            LicensePlate = "22";

        }


        public static State Instance => LazySingleton.Value;
    }
}
