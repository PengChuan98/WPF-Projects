using QR.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

/// <summary>
/// 默认值集合
/// </summary>
public static class ValueBox
{
    // GridViewModel Default Value
    public readonly static int Rows = 16;
    public readonly static int Columns = 6;
    public readonly static int MaxGroup = 1;
    public readonly static int Group = 1;
    public readonly static double CellSize = 25;
    public readonly static System.Windows.Media.Stretch CellStretch = System.Windows.Media.Stretch.Uniform;

    public static void ResetGridViewModel(GridViewModel vm)
    {
        vm.Rows = Rows;
        vm.Columns = Columns;
        vm.MaxGroup = MaxGroup;
        vm.Group = Group;
        vm.CellSize = CellSize;
        vm.CellStretch = CellStretch;

        vm.ItemCollection.Clear();
    }

    // WordProperty Default Value
    public readonly static Order WordOrder = Order.None;
    public readonly static Voice WordVoice = Voice.USA;
    public readonly static Source WordSource = Source.Web;
    public readonly static Pattern WordPattern = Pattern.English;

}