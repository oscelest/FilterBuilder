using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ParkingApp.Converters {
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class ValueToVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            bool result;
            var flagExists = string.IsNullOrEmpty(parameter as string) || (string) parameter == "true";
            var valueAsString = value as string;
            if (valueAsString != null) {
                result = flagExists ? !string.IsNullOrEmpty(valueAsString) : string.IsNullOrEmpty(valueAsString);
            }
            else {
                result = flagExists ? value != null : value == null;
            }

            return result ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
