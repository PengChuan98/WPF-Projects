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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QR.ViewModels;

namespace QR.Shell.Views
{
    /// <summary>
    /// CellView.xaml 的交互逻辑
    /// </summary>
    public partial class CellView : UserControl
    {
        public CellView()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
            => ((CellViewModel)DataContext)?.Glance();

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
            => ((CellViewModel)DataContext)?.Speak();
    }
}
