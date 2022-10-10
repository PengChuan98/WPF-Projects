using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QR.Shell.Controls.ViewsAttach;

public class CellViewAttach
{


    public static double GetCellFontSize(DependencyObject obj)
    {
        return (double)obj.GetValue(CellFontSizeProperty);
    }

    public static void SetCellFontSize(DependencyObject obj, double value)
    {
        obj.SetValue(CellFontSizeProperty, value);
    }

    // Using a DependencyProperty as the backing store for CellFontSize.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CellFontSizeProperty =
        DependencyProperty.RegisterAttached("CellFontSize", typeof(double), typeof(CellViewAttach), new PropertyMetadata(ValueBox.FontSizeValue));



    public static System.Windows.Media.Stretch GetCellStretch(DependencyObject obj)
    {
        return (System.Windows.Media.Stretch)obj.GetValue(CellStretchProperty);
    }

    public static void SetCellStretch(DependencyObject obj, System.Windows.Media.Stretch value)
    {
        obj.SetValue(CellStretchProperty, value);
    }

    // Using a DependencyProperty as the backing store for CellStretch.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CellStretchProperty =
        DependencyProperty.RegisterAttached("CellStretch", typeof(System.Windows.Media.Stretch), typeof(CellViewAttach), new PropertyMetadata(ValueBox.StretchValue));


}