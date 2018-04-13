using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Game
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T: class, new()
    {
        private static T myConverter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return myConverter ?? (myConverter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
