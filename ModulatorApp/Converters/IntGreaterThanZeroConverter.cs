using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ModulatorApp.Converters
{
    public class IntGreaterThanZeroConverter : IValueConverter
    {
        // If parameter == "invert", invert the boolean result.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isGreater = false;
            if (value is int i)
                isGreater = i > 0;
            else if (value is long l)
                isGreater = l > 0;
            else if (value != null && int.TryParse(value.ToString(), out var parsed))
                isGreater = parsed > 0;

            if (parameter is string s && s.Equals("invert", StringComparison.OrdinalIgnoreCase))
                isGreater = !isGreater;

            return isGreater;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}