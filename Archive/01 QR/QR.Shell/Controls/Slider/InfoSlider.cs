using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QR.Shell.Controls;

public class InfoSlider : Slider
{


    public static string GetHeader(DependencyObject obj)
    {
        return (string)obj.GetValue(HeaderProperty);
    }

    public static void SetHeader(DependencyObject obj, string value)
    {
        obj.SetValue(HeaderProperty, value);
    }

    // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.RegisterAttached("Header", typeof(string), typeof(InfoSlider), new PropertyMetadata(""));



    public static double GetHeaderWidth(DependencyObject obj)
    {
        return (double)obj.GetValue(HeaderWidthProperty);
    }

    public static void SetHeaderWidth(DependencyObject obj, double value)
    {
        obj.SetValue(HeaderWidthProperty, value);
    }

    // Using a DependencyProperty as the backing store for HeaderWidth.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty HeaderWidthProperty =
        DependencyProperty.RegisterAttached("HeaderWidth", typeof(double), typeof(InfoSlider), new PropertyMetadata((double)50));


    public static double GetValueWidth(DependencyObject obj)
    {
        return (double)obj.GetValue(ValueWidthProperty);
    }

    public static void SetValueWidth(DependencyObject obj, double value)
    {
        obj.SetValue(ValueWidthProperty, value);
    }

    // Using a DependencyProperty as the backing store for ValueWidth.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueWidthProperty =
        DependencyProperty.RegisterAttached("ValueWidth", typeof(double), typeof(InfoSlider), new PropertyMetadata((double)50));



    public static Thickness GetSliderMargin(DependencyObject obj)
    {
        return (Thickness)obj.GetValue(SliderMarginProperty);
    }

    public static void SetSliderMargin(DependencyObject obj, Thickness value)
    {
        obj.SetValue(SliderMarginProperty, value);
    }

    // Using a DependencyProperty as the backing store for SliderMargin.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SliderMarginProperty =
        DependencyProperty.RegisterAttached("SliderMargin", typeof(Thickness), typeof(InfoSlider), new PropertyMetadata(new Thickness(10,0,10,0)));



    public static double GetSliderWidth(DependencyObject obj)
    {
        return (double)obj.GetValue(SliderWidthProperty);
    }

    public static void SetSliderWidth(DependencyObject obj, double value)
    {
        obj.SetValue(SliderWidthProperty, value);
    }

    // Using a DependencyProperty as the backing store for SliderWidth.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SliderWidthProperty =
        DependencyProperty.RegisterAttached("SliderWidth", typeof(double), typeof(InfoSlider), new PropertyMetadata((double)300));


}