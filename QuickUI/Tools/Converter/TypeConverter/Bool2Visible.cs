using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickUI.Tools;

public class Bool2Visible : BaseValueConvert<Bool2Visible>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => (bool)value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
}