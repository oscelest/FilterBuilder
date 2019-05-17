using System;
using System.Globalization;
using System.Windows.Data;

namespace ParkingApp.Converters {
    public class StringToTranslationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return State.Instance.CurrentLanguage.Translate(parameter as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return parameter;
        }
    }
}
