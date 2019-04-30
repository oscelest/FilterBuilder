using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using Newtonsoft.Json;

namespace ParkingApp.Classes {
    public class Parking {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("time_registered")] public string TimeRegistered { get; set; }
        [JsonProperty("time_completed")] public string TimeCompleted { get; set; }

        public Parking() { }

        public static Dictionary<string, Parking> GetByLicensePlate(string country, string licensePlate) {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"ParkingApp.Resources.Database.json");
            if (stream == null) throw new FileNotFoundException($"ParkingApp.Resources.Database.json");
            var result = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<Parking>>>>(new StreamReader(stream).ReadToEnd());
            return result.ContainsKey(country) && result[country].ContainsKey(licensePlate)
                ? result[country][licensePlate].ToDictionary(parking => parking.Id, parking => parking)
                : new Dictionary<string, Parking>();
        }
    }
}
