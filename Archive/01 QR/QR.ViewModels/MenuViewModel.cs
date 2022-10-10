using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

/// <summary>
/// 菜单视图模型，这个模型的主要作用是发送消息到ShellViewModel中，
/// 让ShellViewModel去处理相关方法
/// </summary>
public class MenuViewModel
{
    public RelayCommand<string?> OpenDialogCommand { get; set; }

    public void OpenDialogSender(string? msg) =>
        MessengerHelper.SendString(msg, MessengerHelper.TOpenFileDialog);

    public RelayCommand<string?> SaveDialogCommand { get; set; }

    public void SaveDialogSender(string? msg) =>
        MessengerHelper.SendString(msg, MessengerHelper.TSaveFileDialog);

    public RelayCommand TestCommand { get; set; }

    public void RunTest()
        => MessengerHelper.SendEmptyString(MessengerHelper.TTestCommand);

    public MenuViewModel()
    {
        OpenDialogCommand = new(OpenDialogSender);
        SaveDialogCommand = new(SaveDialogSender);
        TestCommand = new(RunTest);
    }


}