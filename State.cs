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
        public Keyboard Keyboard { get; set; }

        private State() {
            AvailableLanguages = new List<TranslatorService> {
                new TranslatorService(Language.DANISH, "Danish"),
                new TranslatorService(Language.ENGLISH, "English")
            };
            CurrentLanguage = AvailableLanguages[0];
            LicensePlate = "22";
            Keyboard = new Keyboard()
                .PushRow(new List<char> {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'}, c => LicensePlate += c)
                .PushRow(new List<char> {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'}, c => LicensePlate += c)
                .PushRow(new List<char> {'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'}, c => LicensePlate += c)
                .PushRow(new List<char> {'z', 'x', 'c', 'v', 'b', 'n', 'm'}, c => LicensePlate += c)
                .UnshiftKey(3, '', c => LicensePlate.Remove(LicensePlate.Length - 1))
                .PushKey(3, '', c => LicensePlate = "");

//            Keyboard = new char[4][];
//            Keyboard[0] = new char[] {};
//            Keyboard[1] = new char[] {};
//            Keyboard[2] = new char[] {'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'};
//            Keyboard[3] = new char[] {'z', 'x', 'c', 'v', 'b', 'n', 'm'};
        }


        public static State Instance => LazySingleton.Value;
    }
}
