using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace QR.Shell.Controls.Attach;

public class LabelAttach
{

    #region 双击清除Label显示内容
    public static bool GetQuickRemove(DependencyObject obj)
    {
        return (bool)obj.GetValue(QuickRemoveProperty);
    }

    public static void SetQuickRemove(DependencyObject obj, bool value)
    {
        obj.SetValue(QuickRemoveProperty, value);
    }

    // Using a DependencyProperty as the backing store for QuickRemove.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty QuickRemoveProperty =
        DependencyProperty.RegisterAttached("QuickRemove", typeof(bool), typeof(LabelAttach), new PropertyMetadata(false, OnQuickRemoveChanged));

    private static void OnQuickRemoveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var label = d as Label;
        if (label != null)
        {
            if ((bool)e.NewValue) label.MouseDoubleClick += (s, e) =>
            {
                // 需要设置Mode=TwoWay
                Binding myBinding = BindingOperations.GetBinding(label, Label.ContentProperty);
                label.Content = "";
                BindingOperations.SetBinding(d, Label.ContentProperty, myBinding);
            };
            else label.MouseDoubleClick -= (s, e) => ((Label)s).Content = "";
        }
    }


    #endregion
}