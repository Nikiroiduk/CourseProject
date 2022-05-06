using CourseProjectBL;
using CourseProjectBL.Dictionary;
using CourseProjectBL.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseProjectViewWPF.Converters
{
    class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{CurrencyDictionary.currencySymbolsDictionary[Settings.MainCurrency]} {value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
