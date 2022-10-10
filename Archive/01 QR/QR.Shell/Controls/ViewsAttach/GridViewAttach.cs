using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QR.Shell.Controls.ViewsAttach;

public class GridViewAttach
{


    public static int GetGridRows(DependencyObject obj)
    {
        return (int)obj.GetValue(GridRowsProperty);
    }

    public static void SetGridRows(DependencyObject obj, int value)
    {
        obj.SetValue(GridRowsProperty, value);
    }

    // Using a DependencyProperty as the backing store for GridRows.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty GridRowsProperty =
        DependencyProperty.RegisterAttached("GridRows", typeof(int), typeof(GridViewAttach), new PropertyMetadata(ValueBox.RowsValue));




    public static int GetGridColumns(DependencyObject obj)
    {
        return (int)obj.GetValue(GridColumnsProperty);
    }

    public static void SetGridColumns(DependencyObject obj, int value)
    {
        obj.SetValue(GridColumnsProperty, value);
    }

    // Using a DependencyProperty as the backing store for GridColumns.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty GridColumnsProperty =
        DependencyProperty.RegisterAttached("GridColumns", typeof(int), typeof(GridViewAttach), new PropertyMetadata(ValueBox.ColumnsValue));



}