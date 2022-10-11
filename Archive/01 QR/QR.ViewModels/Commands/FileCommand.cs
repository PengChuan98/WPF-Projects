using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels.Commands;

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
}