using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

public class StatusViewModel : ObservableObject
{
    private string _log = "";
    public string ShellLog
    {
        get => _log;
        set => SetProperty(ref _log, value);
    }


    public StatusViewModel()
    {
        // 全局日志
        MessengerHelper.RegisterString(this, MessengerHelper.TInfoLog, (s, e) => { ShellLog = e; });

        MessengerHelper.RegisterString(this, MessengerHelper.TWarnLog, (s, e) => { ShellLog = e; });

        MessengerHelper.RegisterString(this, MessengerHelper.TErrorLog, (s, e) => { ShellLog = e; });
    }
}