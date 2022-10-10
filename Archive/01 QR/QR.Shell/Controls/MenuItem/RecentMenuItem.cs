using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Toolkits.Helpers;

namespace QR.Shell.Controls;

public class RecentMenuItem : System.Windows.Controls.MenuItem
{
    public List<string> RecentPath
    {
        get { return (List<string>)GetValue(RecentPathProperty); }
        set { SetValue(RecentPathProperty, value); }
    }

    // Using a DependencyProperty as the backing store for RecentPath.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty RecentPathProperty =
        DependencyProperty.Register("RecentPath", typeof(List<string>), typeof(RecentMenuItem), new PropertyMetadata(new List<string>(), OnValueChanged));

    bool IsMutex = false;

    private static string StrictString(string value, int count, string replace = " ......")
    {
        if (value.Length > count)
        {
            return value.Substring(0, count).ToString() + replace;
        }
        else
        {
            return value;
        }
    }

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var item = (RecentMenuItem)d;

        // 加个锁，防止栈溢出
        if (!item.IsMutex)
        {
            item.IsMutex = true;

            List<System.Windows.Controls.MenuItem> source = new();

            var temp = ListHelper<string>.UniqueRange(item.RecentPath, 10);

            // 去除空字符
            var result = new List<string>();
            temp?.ForEach(item =>
            {
                if (!string.IsNullOrEmpty(item.Trim()))
                {
                    result.Add(item.Trim());
                }
            });

            int length = 50;

            if (result != null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    source.Add(new System.Windows.Controls.MenuItem()
                    {
                        Header = StrictString(result[i], length),
                        Command = item.Command,
                        ToolTip = result[i].Length > length ? result[i] : null,
                        CommandParameter = result[i],
                        HorizontalContentAlignment = item.HorizontalContentAlignment,
                        VerticalContentAlignment = item.VerticalContentAlignment,
                    });
                }
                source.Reverse();
                item.ItemsSource = source;
                item.RecentPath = result;
            }

            item.IsMutex = false;
        }
    }
}