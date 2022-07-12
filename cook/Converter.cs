using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace cook
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class BoolStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value?.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class CountValidate:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!int.TryParse(value.ToString(), out var count))
            {
                return new ValidationResult(false, "Incorrect");
            }

            return count <= 0 ? new ValidationResult(false, "Invalid Count") : ValidationResult.ValidResult;
        }
    }
}
