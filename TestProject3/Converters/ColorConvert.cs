using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TestProject3.Converters
{
    class ColorConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is string)
                {
                    return (Color)ColorConverter.ConvertFromString(value.ToString());
                }
                return ((Color) value).ToString();
            }
            return "Black";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}