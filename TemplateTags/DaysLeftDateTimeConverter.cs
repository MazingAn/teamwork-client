using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace TeamworkClient.TemplateTags
{
    class DaysLeftDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;
            DateTime date = (DateTime)value;
            TimeSpan deltaTime = date - DateTime.Now;
            return (int)deltaTime.TotalDays + "天后结束";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
