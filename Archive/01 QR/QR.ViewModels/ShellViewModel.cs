﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using QR.Core.Models;
using QR.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

public class ShellViewModel : ObservableObject
{
    List<MetaWord> Words = new();

    #region 通知属性
    private string _log = "";
    public string ShellLog
    {
        get => _log;
        set => SetProperty(ref _log, value);
    }

    private CellViewModel _cellviewmodel;
    public CellViewModel CellVM
    {
        get => _cellviewmodel;
        set => SetProperty(ref _cellviewmodel, value);
    }

    #endregion

    #region 消息方法
    public void OpenFileWithDialog(object s, string e)
    {
        try
        {
            if (e.ToLower() == "csv")
            {
                var recall = DialogService.OpenFileDlg(DialogService.FilterBuilder("csv", true), out string path);
                if (!recall)
                {
                    MessengerHelper.SendString("CSV文件打开失败", MessengerHelper.TErrorLog);
                }

                if (FileService.ReadStringFile(path, out string content) && WordService.FromCSV(content, out Words))
                {
                    MessengerHelper.SendString(string.Format("加载了{0}个单词 . 加载地址 : {1}", Words.Count, path), MessengerHelper.TInfoLog);
                }

            }
            else if (e.ToLower() == "words")
            {
                var recall = DialogService.OpenFileDlg(DialogService.FilterBuilder("words", true), out string path);
                if (!recall)
                {
                    MessengerHelper.SendString("Words文件打开失败", MessengerHelper.TErrorLog);
                }

                if (FileService.ReadByteFile(path, out var content) && WordService.FromBytes(content, out Words))
                {
                    MessengerHelper.SendString(string.Format("加载了{0}个单词 . 加载地址 : {1}", Words.Count, path), MessengerHelper.TInfoLog);
                }
            }
            else
            {
                throw new Exception("类型参数错误，当前参数类型为：" + e);
            }

        }
        catch (Exception exception)
        {
            MessengerHelper.SendString(exception.Message, MessengerHelper.TErrorLog);
        }
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


        // 打开文件窗口
        MessengerHelper.RegisterString(this, MessengerHelper.TOpenFileDialog, OpenFileWithDialog);

        // 测试
        MessengerHelper.RegisterString(this, MessengerHelper.TTestCommand, Test);
    }

    private int index = 0;
    private void Test(object recipient, string message)
    {
        var word = Words[index];
        CellVM = new(word, new());
        CellVM.Reset();
        index++;
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
