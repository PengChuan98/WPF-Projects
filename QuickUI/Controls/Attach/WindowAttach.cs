using System.Windows;
using System.Windows.Input;

namespace QuickUI.Controls.Attach;

public class WindowAttach
{
    #region 拖动窗口
    public static readonly DependencyProperty IsDragElementProperty = DependencyProperty.RegisterAttached(
        "IsDragElement", typeof(bool), typeof(WindowAttach), new PropertyMetadata(false, OnIsDragElementChanged));

    public static void SetIsDragElement(DependencyObject element, bool value)
        => element.SetValue(IsDragElementProperty, value);

    public static bool GetIsDragElement(DependencyObject element)
        => (bool)element.GetValue(IsDragElementProperty);

    private static void OnIsDragElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is UIElement ctl)
        {
            if ((bool)e.NewValue)
            {
                ctl.MouseLeftButtonDown += DragElement_MouseLeftButtonDown;
            }
            else
            {
                ctl.MouseLeftButtonDown -= DragElement_MouseLeftButtonDown;
            }
        }
    }

    private static void DragElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (sender is DependencyObject obj && e.ButtonState == MouseButtonState.Pressed)
        {
            System.Windows.Window.GetWindow(obj)?.DragMove();
        }
    }
    #endregion

    #region 窗口置顶
    public static readonly DependencyProperty IsTopmostElementProperty = DependencyProperty.RegisterAttached(
       "IsTopmostElement", typeof(bool), typeof(WindowAttach), new PropertyMetadata(false, OnIsTopmostElementChanged));

    public static void SetIsTopmostElement(DependencyObject element, bool value)
        => element.SetValue(IsDragElementProperty, value);

    public static bool GetIsTopmostElement(DependencyObject element)
        => (bool)element.GetValue(IsDragElementProperty);

    private static void OnIsTopmostElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => Window.GetWindow((DependencyObject)d)?.SetValue(Window.TopmostProperty, (bool)e.NewValue);

    #endregion
}