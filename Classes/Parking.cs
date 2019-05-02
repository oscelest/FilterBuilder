using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using Newtonsoft.Json;
using ParkingApp.Enum;

namespace ParkingApp.Classes {
    public class Parking {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("time_registered")] public DateTime TimeRegistered { get; set; }
        [JsonProperty("time_completed")] public DateTime? TimeCompleted { get; set; }

        public Parking() { }

        public static Dictionary<string, Parking> GetByLicensePlate(Country country, string licensePlate) {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"ParkingApp.Resources.Database.json");
            if (stream == null) throw new FileNotFoundException($"ParkingApp.Resources.Database.json");
            var result = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<Parking>>>>(new StreamReader(stream).ReadToEnd());
            return result.ContainsKey(country.ToString()) && result[country.ToString()].ContainsKey(licensePlate)
                ? result[country.ToString()][licensePlate].ToDictionary(parking => parking.Id, parking => parking)
                : new Dictionary<string, Parking>();
        }
    }
}
