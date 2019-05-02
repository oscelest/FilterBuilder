using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ParkingApp.Converters {
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class CountryToFlagResourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return $"pack://application:,,,/ParkingApp;component/Resources/Images/{value}.png";;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
