using System;
using System.Collections.Generic;
using FilterBuilder.Enum;
using FilterBuilder.Helper;
using FilterBuilder.Service;

namespace FilterBuilder {
    public class State {
        private static readonly Lazy<State> LazySingleton = new Lazy<State>(() => new State());

        public List<TranslatorService> AvailableLanguages { get; }
        public TranslatorService CurrentLanguage { get; set; }
        public string LicensePlate { get; set; }

        private State() {
            var keyboard = new Keyboard(new char[4][], (sender, args) => {  });

            AvailableLanguages = new List<TranslatorService> {
                new TranslatorService(Language.DANISH, "Danish", keyboard),
                new TranslatorService(Language.ENGLISH, "English", keyboard)
            };
            CurrentLanguage = AvailableLanguages[0];
            LicensePlate = "22";
        }


        public static State Instance => LazySingleton.Value;
    }
}
