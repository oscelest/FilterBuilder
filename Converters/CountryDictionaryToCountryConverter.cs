using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using ParkingApp.Enum;

namespace ParkingApp.Converters {
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class CountryDictionaryToCountryConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return new KeyValuePair<Language, Country>(State.Instance.AvailableCountries.FirstOrDefault(x => x.Value == value).Key, value as Country);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            var t = value as KeyValuePair<Language, Country>?;
            return t != null ? t.Value.Value : value;
        }
    }
}
