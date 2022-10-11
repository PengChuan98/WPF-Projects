using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels.Commands;

public class TestCommand
{
    public RelayCommand Test1 { get; set; }

    public void RunTest()
        => MessengerHelper.SendEmptyString(MessengerHelper.TTestCommand);

    public TestCommand()
    {
        Test1 = new(RunTest);
    }
}