using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace TeamworkClient.TemplateTags
{
    class LocalDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;
            DateTime date = (DateTime)value;
            return date.ToString("yyyy-MM-dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            DateTime txtDate;
            if (DateTime.TryParse(str, out txtDate))
            {
                return txtDate;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
