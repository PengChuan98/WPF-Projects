using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QuickUI.Tools;

public class Enum2Bool : BaseValueConvert<Enum2Bool>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
         => value == null ? false : value.Equals(parameter);

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value != null && value.Equals(true) ? parameter : Binding.DoNothing;
}