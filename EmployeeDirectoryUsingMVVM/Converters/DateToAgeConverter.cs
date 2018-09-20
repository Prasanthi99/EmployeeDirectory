using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EmployeeDirectoryUsingMVVM
{
    public class DateToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            int age = 0;
            if (!DateTime.TryParse(value.ToString(), out DateTime date))
                return null;
            age = DateTime.Now.Year - date.Year;
            if (DateTime.Now.DayOfYear < date.DayOfYear)
                age = age - 1;
            return age.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
