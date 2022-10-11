using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using QR.Core.Models;
using QR.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolkits.Helpers;
using QR.ViewModels.Commands;

namespace QR.ViewModels;

public class ShellViewModel : ObservableObject
{

    #region 单词设置字段
    // 单词配置文件（所有的Panel模式都能用）
    WordProperty WProperty = new();

    public Order WordOrder
    {
        get => WProperty.Order;
        set => SetProperty(ref WProperty.Order, value);
    }

    public Voice WordVoice
    {
        get => WProperty.Voice;
        set => SetProperty(ref WProperty.Voice, value);
    }
    public Source WordSource
    {
        get => WProperty.Source;
        set => SetProperty(ref WProperty.Source, value);
    }
    public Pattern WordPattern
    {
        get => WProperty.Pattern;
        set => SetProperty(ref WProperty.Pattern, value);
    }

    /// <summary>
    /// 还原初始状态
    /// </summary>
    public void ResetWordProperty()
    {
        WordOrder = ValueBox.WordOrder;
        WordVoice = ValueBox.WordVoice;
        WordSource = ValueBox.WordSource;
        WordPattern = ValueBox.WordPattern;
    }

    #endregion

    #region 全局设置字段
    #endregion

    #region ViewModels
    // TODO 多种模式的面板数据对象
    public GridViewModel GViewModel { get; set; } = new();

    // 状态栏
    public StatusViewModel SViewModel { get; set; } = new();

    // 菜单栏
    public MenuViewModel MViewModel { get; set; } = new();
    #endregion

    #region 全局核心字段
    // 最后一次记录的文件地址
    string LastPath = String.Empty;

    // 当前打开文件的内容集合
    List<MetaWord> Words = new();

    // 待操作视图模型集合
    public List<CellViewModel> CellViewModelCollection { get; set; } = new();
    #endregion

    #region 临时核心字段

    #endregion

    #region TODO 待实现功能（面板）
    //private object _panelviewmodel = new();
    //public object PanelViewModel
    //{
    //    get => _panelviewmodel;
    //    set => SetProperty(ref _panelviewmodel, value);
    //}
    #endregion

    #region 消息方法
    /// <summary>
    /// 注册消息初始化
    /// </summary>
    public void MessengerInitialized()
    {
        // 文件
        MessengerHelper.RegisterString(this, MessengerHelper.TOpenFileDialog, OpenFileWithDialog);
        MessengerHelper.RegisterString(this, MessengerHelper.TSaveFileDialog, SaveFileWithDialog);

        // 打开文件之后
        MessengerHelper.RegisterString(this, MessengerHelper.TLoadWordsSuccess, OpenFileWithDialogSuccess);

        // GridView
        MessengerHelper.RegisterString(this, MessengerHelper.TGridSizeChanged, OnGridSizeChanged);
        MessengerHelper.RegisterString(this, MessengerHelper.TGridGroupChanged, OnGridGroupChanged);
    }

    /// <summary>
    /// 渲染Grid
    /// </summary>
    private void RenderGridPanel()
    {
        // 获取显示数据
        var temp = ListHelper<CellViewModel>.Split(CellViewModelCollection, GViewModel.Columns * GViewModel.Rows, GViewModel.Group);
        SortItems(temp, WProperty.Order);

        // 赋值
        GViewModel.ItemCollection = temp;
    }

    private void OnGridGroupChanged(object recipient, string message)
    {
        try
        {
            RenderGridPanel();
        }
        catch (Exception e)
        {
            MessengerHelper.SendString(e.Message, MessengerHelper.TErrorLog);
        }
    }

    /// <summary>
    /// Grid面板的Columns和Rows值改变的时候
    /// 因为这两个值的更改一定伴随着Group和MaxGroup的重新定义问题，所以这里只需要计算Group和MaxGroup
    /// 然后数据视图的刷新放到Group和MaxGroup中
    /// </summary>
    /// <param name="recipient"></param>
    /// <param name="message"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void OnGridSizeChanged(object recipient, string message)
    {
        try
        {
            // 计算
            GViewModel.MaxGroup = (int)Math.Ceiling(Words.Count / (double)(GViewModel.Rows * GViewModel.Columns));

            // 显示
            RenderGridPanel();
        }
        catch (Exception e)
        {
            MessengerHelper.SendString(e.Message, MessengerHelper.TErrorLog);
        }
    }

    /// <summary>
    /// 打开文件
    /// </summary>
    /// <param name="s"></param>
    /// <param name="e"></param>
    public void OpenFileWithDialog(object s, string e)
    {
        if (e.ToLower() == "csv") Handles.FileHandle.ReadCSVFileWithDialog(out LastPath, out Words);
        else if (e.ToLower() == "words") Handles.FileHandle.ReadWordsFileWithDialog(out LastPath, out Words);
        else MessengerHelper.SendString("类型参数错误，当前参数类型为：" + e, MessengerHelper.TErrorLog);
    }

    /// <summary>
    /// 打开文件加载数据之后初始化然后渲染界面
    /// </summary>
    /// <param name="recipient"></param>
    /// <param name="message"></param>
    private void OpenFileWithDialogSuccess(object recipient, string message)
    {
        try
        {
            // 全局初始化
            CellViewModelCollection = new();
            ResetWordProperty();

            // 填充原始数据和临时数据
            Words.ForEach(item => { CellViewModelCollection.Add(new(item, WProperty)); });

            // 初始化配置文件
            ValueBox.ResetGridViewModel(GViewModel);

            // 计算
            GViewModel.MaxGroup = (int)Math.Ceiling(Words.Count / (double)(GViewModel.Rows * GViewModel.Columns));

            // 显示
            RenderGridPanel();
        }
        catch (Exception e)
        {
            MessengerHelper.SendString(e.Message, MessengerHelper.TErrorLog);
        }
    }



    /// <summary>
    /// 关闭文件
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="e"></param>
    public void SaveFileWithDialog(object obj, string e)
    {
        if (e.ToLower() == "csv") Handles.FileHandle.SaveCSVFileWithDialog(Words, out LastPath);
        else if (e.ToLower() == "words") Handles.FileHandle.SaveWordsFileWithDialog(Words, out LastPath);
        else MessengerHelper.SendString("类型参数错误，当前参数类型为：" + e, MessengerHelper.TErrorLog);
    }
    #endregion


    /// <summary>
    /// 通过WordProperty的Order来排序
    /// </summary>
    /// <param name="items"></param>
    /// <param name="order"></param>
    private void SortItems(List<CellViewModel> items, Order order)
    {
        switch (order)
        {
            case Order.None:
                break;
            case Order.Sequence:
                items.Sort((x, y) =>
                {
                    string src = x.Meta.Word.ToLower();
                    string dst = y.Meta.Word.ToLower();
                    return src.CompareTo(dst);
                });
                break;
            case Order.Reserve:
                items.Sort((x, y) =>
                {
                    string src = x.Meta.Word.ToLower();
                    string dst = y.Meta.Word.ToLower();
                    return dst.CompareTo(src);
                });
                break;
            case Order.Random:
                ListHelper<CellViewModel>.Random(items);
                break;
            default:
                break;
        }
    }

    public ShellViewModel()
    {
        MessengerInitialized();

        //PanelViewModel = GViewModel;
    }
}
