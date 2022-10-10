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

namespace QR.ViewModels;

public class ShellViewModel : ObservableObject
{
    string LastPath = QR.Core.Helper.ValueHelper.EmptyString;

    List<MetaWord> MetaWordCollection = new();

    public List<CellViewModel>? CellViewModelCollection { get; set; }

    #region 通知属性
    private string _log = "";
    public string ShellLog
    {
        get => _log;
        set => SetProperty(ref _log, value);
    }

    private List<CellViewModel> _itemCollection = new();

    /// <summary>
    /// 显示用的视图模型集合
    /// </summary>
    public List<CellViewModel> ItemCollection
    {
        get => _itemCollection;
        set => SetProperty(ref _itemCollection, value);
    }

    #endregion

    #region 消息方法
    public void OpenFileWithDialog(object s, string e)
    {
        if (e.ToLower() == "csv") Handles.FileHandle.ReadCSVFileWithDialog(out LastPath, out MetaWordCollection);
        else if (e.ToLower() == "words") Handles.FileHandle.ReadWordsFileWithDialog(out LastPath, out MetaWordCollection);
        else MessengerHelper.SendString("类型参数错误，当前参数类型为：" + e, MessengerHelper.TErrorLog);

    }

    public void SaveFileWithDialog(object obj,string e)
    {
        if (e.ToLower() == "csv") Handles.FileHandle.SaveCSVFileWithDialog(MetaWordCollection,out LastPath);
        else if (e.ToLower() == "words") Handles.FileHandle.SaveWordsFileWithDialog(MetaWordCollection, out LastPath);
        else MessengerHelper.SendString("类型参数错误，当前参数类型为：" + e, MessengerHelper.TErrorLog);
    }
    #endregion

    /// <summary>
    /// 注册消息服务
    /// </summary>
    public void MessengerInitialized()
    {
        // 全局日志
        MessengerHelper.RegisterString(this, MessengerHelper.TInfoLog, (s, e) => { ShellLog = e; });

        MessengerHelper.RegisterString(this, MessengerHelper.TWarnLog, (s, e) => { ShellLog = e; });

        MessengerHelper.RegisterString(this, MessengerHelper.TErrorLog, (s, e) => { ShellLog = e; });


        // 文件
        MessengerHelper.RegisterString(this, MessengerHelper.TOpenFileDialog, OpenFileWithDialog);
        MessengerHelper.RegisterString(this, MessengerHelper.TSaveFileDialog, SaveFileWithDialog);

        // 测试
        MessengerHelper.RegisterString(this, MessengerHelper.TTestCommand, Test);
    }

    private int index = 1;
    private void Test(object recipient, string message)
    {
        var property = new WordProperty();
        CellViewModelCollection = new();
        MetaWordCollection.ForEach(
            item => { CellViewModelCollection.Add(new(item, property)); }
            );

        var items = ListHelper<CellViewModel>.Split(CellViewModelCollection, 10 * 10, index);

        items.Sort((x, y) =>
        {
            string src = x.Meta.Word.ToLower();
            string dst = y.Meta.Word.ToLower();
            return src.CompareTo(dst);
        });


        ItemCollection = items;
    }

    /// <summary>
    /// 命令初始化
    /// </summary>
    public void CommandInitialized()
    {

    }


    public ShellViewModel()
    {
        MessengerInitialized();
    }
}
