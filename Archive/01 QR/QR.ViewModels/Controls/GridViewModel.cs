using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

/// <summary>
/// 
/// </summary>
public class GridViewModel : ObservableObject
{
    /// <summary>
    /// 初始化配置文件
    /// </summary>
    public QR.Core.Models.GridProperty GProperty { get; set; } = new();

    #region 设置
    public int Rows
    {
        get => GProperty.Rows;
        set
        {
            // 计算新的Group位置
            int index = GProperty.Rows * GProperty.Columns * (GProperty.Group - 1);
            int size = GProperty.Columns * value;
            Group = (int)Math.Floor(index / (double)size) + 1;

            // 赋值
            SetProperty(ref GProperty.Rows, value);

            OnSizeChanged();
        }
    }

    public int Columns
    {
        get => GProperty.Columns;
        set 
        {
            // 计算新的Group位置
            int index = GProperty.Rows * GProperty.Columns * (GProperty.Group - 1);
            int size = GProperty.Rows * value;
            Group = (int)Math.Floor(index / (double)size) + 1;

            SetProperty(ref GProperty.Columns, value);

            OnSizeChanged();
        }
    }

    public int Group
    {
        get => GProperty.Group;
        set => SetProperty(ref GProperty.Group, value);
    }

    public int MaxGroup
    {
        get => GProperty.MaxGroup;
        set => SetProperty(ref GProperty.MaxGroup, value);
    }

    public double CellSize
    {
        get => GProperty.CellSize;
        set => SetProperty(ref GProperty.CellSize, value);
    }
    public System.Windows.Media.Stretch CellStretch
    {
        get => GProperty.CellStretch;
        set => SetProperty(ref GProperty.CellStretch, value);
    }

    #endregion

    #region 数据

    private List<CellViewModel> _itemCollection = null;

    public List<CellViewModel> ItemCollection
    {
        get => _itemCollection;
        set => SetProperty(ref _itemCollection, value);
    }

    #endregion

    #region OnValueChanged

    /// <summary>
    /// 当Columns和Rows改变的时候
    /// </summary>
    public void OnSizeChanged()
        => MessengerHelper.SendEmptyString(MessengerHelper.TGridSizeChanged);


    #endregion

    public void ResetProperty()
    {
        Rows = ValueBox.Rows;
    }
}