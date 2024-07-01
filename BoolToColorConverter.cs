using Microsoft.Maui.Graphics;
using System;
using System.Globalization;

namespace Manufacturing_Society_App.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isIncoming)
            {
                return isIncoming ? Color.FromArgb("#004890") : Color.FromArgb("#f23553");
            }
            return Color.FromArgb("#FFFFFF"); // Default color if conversion fails
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
