using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace TeamworkClient.TemplateTags
{
    class ProjectStatusConverter : IValueConverter
    {

        string[] projectStatusKind = {"start", "stop"};

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";
            return projectStatusKind[(int)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
