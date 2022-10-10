using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    #region 属性
    List<MetaWord> Words = new();
    #endregion

    #region 通知属性
    private string _log = "";
    public string ShellLog
    {
        get => _log;
        set => SetProperty(ref _log, value);
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
                    Manager.SendString("CSV文件打开失败", Manager.TErrorLog);
                }

                if (FileService.ReadStringFile(path, out string content) && WordService.FromCSV(content, out Words))
                {
                    Manager.SendString(string.Format("加载了{0}个单词 . 加载地址 : {1}", Words.Count, path), Manager.TInfoLog);
                }

            }
            else if (e.ToLower() == "words")
            {
                var recall = DialogService.OpenFileDlg(DialogService.FilterBuilder("words", true), out string path);
                if (!recall)
                {
                    Manager.SendString("Words文件打开失败", Manager.TErrorLog);
                }

                if (FileService.ReadByteFile(path, out var content) && WordService.FromBytes(content, out Words))
                {
                    Manager.SendString(string.Format("加载了{0}个单词 . 加载地址 : {1}", Words.Count, path), Manager.TInfoLog);
                }
            }
            else
            {
                throw new Exception("类型参数错误，当前参数类型为：" + e);
            }

        }
        catch (Exception exception)
        {
            Manager.SendString(exception.Message, Manager.TErrorLog);
        }
    }
    #endregion

    /// <summary>
    /// 注册消息服务
    /// </summary>
    public void MessengerInitialized()
    {
        // 全局日志
        Manager.RegisterString(this, Manager.TInfoLog, (s, e) => { ShellLog = e; });

        Manager.RegisterString(this, Manager.TWarnLog, (s, e) => { ShellLog = e; });

        Manager.RegisterString(this, Manager.TErrorLog, (s, e) => { ShellLog = e; });


        // 打开文件窗口
        Manager.RegisterString(this, Manager.TOpenFileDialog, OpenFileWithDialog);
    }




    public ShellViewModel()
    {
        MessengerInitialized();
    }
}
