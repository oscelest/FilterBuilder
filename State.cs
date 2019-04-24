using System;
using System.Collections.Generic;
using FilterBuilder.Enum;

namespace FilterBuilder.Model {
    public class State {
        private static readonly Lazy<State> LazySingleton = new Lazy<State>(() => new State());

        private State() {
            AvailableLanguages = new List<TranslatorService> {
                new TranslatorService(Language.DANISH, "Danish"),
                new TranslatorService(Language.ENGLISH, "English")
            };
            CurrentLanguage = AvailableLanguages[0];
        }

        public List<TranslatorService> AvailableLanguages { get; }
        public TranslatorService CurrentLanguage { get; set; }

        public static State Instance => LazySingleton.Value;
    }
}
