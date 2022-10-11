using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

public class SettingViewModel : ObservableObject
{
    private bool _topmost = true;
    public bool TopMost
    {
        get => _topmost;
        set => SetProperty(ref _topmost, value);
    }

    private bool _hide = true;
    public bool Hide
    {
        get => _hide;
        set => SetProperty(ref _hide, value);
    }

}