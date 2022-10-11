using Microsoft.Toolkit.Mvvm.ComponentModel;
using QR.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

public class MenuViewModel : ObservableObject
{
    #region Commands
    public FileCommand FCommand { get; set; } = new();
    public TestCommand TCommand { get; set; } = new();
    #endregion

    public MenuViewModel()
    {
        
    }
}