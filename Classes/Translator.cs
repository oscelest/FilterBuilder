using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ParkingApp.Enum;
using ParkingApp.Helper;
using Newtonsoft.Json;

namespace ParkingApp.Classes {
    public class Translator {
        public Translator(Language id, string title) {
            Id = id;
            Title = title;
            Icon = $"pack://application:,,,/ParkingApp;component/Resources/Images/{id}.png";
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"ParkingApp.Resources.Translations.{id}.json");
            if (stream == null) throw new FileNotFoundException($"ParkingApp.Resources.Translations.{id}.json");
            Translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(new StreamReader(stream).ReadToEnd());
        }

        public Language Id { get; }
        public string Icon { get; }
        public string Title { get; }
        public Dictionary<string, string> Translations { get; }

        public string Translate(string token) {
            return Translations.ContainsKey(token) ? Translations[token] : "TRANSLATION_MISSING";
        }
    }
}
