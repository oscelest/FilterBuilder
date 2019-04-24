using System;
using System.Collections.Generic;
using FilterBuilder.Enum;

namespace FilterBuilder.Model {
    public class State {
        private static readonly Lazy<State> LazySingleton = new Lazy<State>(() => new State());

        private State() {
            AvailableLanguages = new List<Translator> {
                new Translator(Language.DANISH, "Danish"),
                new Translator(Language.ENGLISH, "English")
            };
            CurrentLanguage = AvailableLanguages[0];
        }

        public List<Translator> AvailableLanguages { get; }
        public Translator CurrentLanguage { get; set; }

        public static State Instance => LazySingleton.Value;
    }
}
