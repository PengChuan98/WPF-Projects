using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BindingDemo
{
    /// <summary>
    /// DemoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DemoWindow : Window
    {
        DemoViewModel value;
        public DemoWindow(DemoViewModel model)
        {
            InitializeComponent();
            this.value = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(this.tb.Text, out var v))
            {
                value.Value = v;
            }
            else
            {
                MessageBox.Show("error");
            }
        }
    }
}
