using System;
using System.Globalization;
using System.Windows.Data;

namespace CourseProjectViewWPF.Converters
{
    public class PasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string pass)
            {
                return pass;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string pass)
            {
                return new string('*', pass.Length);
            }
            return "Mmmm?!";
        }
    }
}
