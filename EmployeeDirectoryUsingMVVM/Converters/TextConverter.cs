using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EmployeeDirectoryUsingMVVM
{
    class TextConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] != null && value[1] != null)
            {
                bool isFirstNameNull = (value[0].ToString() == string.Empty);
                bool isLastNameNull = (value[1].ToString() == string.Empty);
                if (!isFirstNameNull && !isLastNameNull)
                    return $"{value[0].ToString().ToUpper()[0]}{value[1].ToString().ToUpper()[0]}";
                else if (!isLastNameNull)
                    return $"{value[1].ToString().Substring(0, 2).ToUpper()}";
                else if (!isFirstNameNull)
                    return $"{value[0].ToString().Substring(0, 2).ToUpper()}";

                return null;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}