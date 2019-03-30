using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace VazaniDat
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var datum = ((DateTime)value).Date;

            if (datum == DateTime.Today) return "dnes";
            if (datum == DateTime.Today.AddDays(-1)) return "včera";
            if (datum == DateTime.Today.AddDays(-2)) return "předevčírem";
            if (datum == DateTime.Today.AddDays(1)) return "zítra";

            return datum.ToString("dd.MM.yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
