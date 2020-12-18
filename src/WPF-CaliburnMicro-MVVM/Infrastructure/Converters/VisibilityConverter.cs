using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_CaliburnMicro_MVVM.Infrastructure.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visible = value is bool && (bool)value;
            var notVisible = Visibility.Collapsed;
            if (parameter is Visibility)
            {
                notVisible = Visibility.Hidden;
            }
            return visible ? Visibility.Visible : notVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
