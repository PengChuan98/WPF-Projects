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
        Manager.SendString(msg, Manager.TOpenFileDialog);

    public MenuViewModel()
    {
        OpenDialogCommand = new(OpenDialogSender);
    }


}