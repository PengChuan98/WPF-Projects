using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels.Commands;

/// <summary>
/// 操作文件通用指令
/// </summary>
public class FileCommand
{
    public RelayCommand<string?> OpenDialogCommand { get; set; }

    public void OpenDialogSender(string? msg) =>
        MessengerHelper.SendString(msg, MessengerHelper.TOpenFileDialog);

    public RelayCommand<string?> SaveDialogCommand { get; set; }

    public void SaveDialogSender(string? msg) =>
        MessengerHelper.SendString(msg, MessengerHelper.TSaveFileDialog);

  

    public FileCommand()
    {
        OpenDialogCommand = new(OpenDialogSender);
        SaveDialogCommand = new(SaveDialogSender);
    }

    /// <summary>
    /// 打开文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="words"></param>
    public void OpenFile(string path, out List<QR.Core.Models.MetaWord> words)
    {
        words = new();
        try
        {

        }
        catch (Exception e)
        {
            MessengerHelper.SendErrorLog(e.Message);
        }
    }

    /// <summary>
    /// 借助文件打开窗口打开文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="words"></param>
    public void OpenFileWithDialog(out string path,out List<QR.Core.Models.MetaWord> words)
    {
        path = "";
        words = new();
        try
        {

        }
        catch (Exception e)
        {
            MessengerHelper.SendErrorLog(e.Message);
        }
    }


    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="words"></param>
    public void SaveFile(string path, List<QR.Core.Models.MetaWord> words)
    {
        try
        {

        }
        catch (Exception e)
        {
            MessengerHelper.SendErrorLog(e.Message);
        }
    }

    /// <summary>
    /// 借助文件打开窗口保存文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="words"></param>
    public void SaveFileWithDialog(out string path, List<QR.Core.Models.MetaWord> words)
    {
        path = "";
        try
        {

        }
        catch (Exception e)
        {
            MessengerHelper.SendErrorLog(e.Message);
        }
    }
}