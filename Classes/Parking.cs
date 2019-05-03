using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Media;
using Newtonsoft.Json;
using ParkingApp.Enum;
using static System.Int32;

namespace ParkingApp.Classes {
    public class Parking {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("time_registered")] public DateTime TimeRegistered { get; set; }
        [JsonProperty("time_completed")] public DateTime? TimeCompleted { get; set; }

        private static Dictionary<string, Dictionary<string, List<Parking>>> _database;

        public Parking() { }

        private static void ReadDatabase() {
            _database = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<Parking>>>>(File.ReadAllText(State.Instance.DatabasePath));
        }

        private static void WriteDatabase() {
            File.WriteAllText(State.Instance.DatabasePath, JsonConvert.SerializeObject(_database));
        }

        public static Dictionary<string, Parking> GetByLicensePlate(Country country, string licensePlate) {
            if (_database == null) ReadDatabase();
            return _database.ContainsKey(country.ToString()) && _database[country.ToString()].ContainsKey(licensePlate)
                ? _database[country.ToString()][licensePlate].ToDictionary(parking => parking.Id, parking => parking)
                : new Dictionary<string, Parking>();
        }

        public static void Post(Country country, string licensePlate) {
            if (_database == null) ReadDatabase();

            if (!_database.ContainsKey(country.ToString())) _database[country.ToString()] = new Dictionary<string, List<Parking>>();
            if (!_database[country.ToString()].ContainsKey(licensePlate)) _database[country.ToString()][licensePlate] = new List<Parking>();
            _database[country.ToString()][licensePlate].Add(new Parking {Id = Guid.NewGuid().ToString(), TimeRegistered = DateTime.Now, TimeCompleted = null});

            WriteDatabase();
        }

        public static void Put(Country country, string licensePlate) {
            if (_database == null) ReadDatabase();

            foreach (var parking in _database[country.ToString()][licensePlate]) {
                if (parking.TimeCompleted == null) parking.TimeCompleted = DateTime.Now;
            }

            WriteDatabase();
        }

    }
}
