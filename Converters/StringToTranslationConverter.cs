using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using FilterBuilder.Service;

namespace FilterBuilder.Converters {
    public class StringToTranslationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return State.Instance.CurrentLanguage.Translate(parameter as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return parameter;
        }
    }
}
