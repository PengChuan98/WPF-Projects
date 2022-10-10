using System.Windows;

namespace QuickUI.Controls.Attach;

public class ElementAttach
{
    #region 隐藏元素 默认使用的是Collapsed
    public static readonly DependencyProperty IsHideProperty = DependencyProperty.RegisterAttached(
        "IsHide", typeof(bool), typeof(ElementAttach), new FrameworkPropertyMetadata(false, OnHideChanged));

    private static void OnHideChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        UIElement? element = d as UIElement;
        if (element!=null)
        {
            element.Visibility = (bool)e.NewValue ? Visibility.Collapsed : Visibility.Visible;
        }
    }

    public static void SetIsHideProperty(DependencyObject element, bool value)
        => element.SetValue(IsHideProperty, value);

    public static bool GetIsHideProperty(DependencyObject element)
        => (bool)element.GetValue(IsHideProperty);
    #endregion
}