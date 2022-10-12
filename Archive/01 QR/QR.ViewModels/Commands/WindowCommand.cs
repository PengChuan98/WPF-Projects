using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QR.ViewModels.Commands;

public class WindowCommand
{
    public RelayCommand<Window?> FullScreenCommand { get; set; }

    public void SwitchFullWindow(Window? window)
    {

    }

    public WindowCommand()
    {
        FullScreenCommand = new(SwitchFullWindow);
    }
}