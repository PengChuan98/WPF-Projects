using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BindingDemo;
public class DemoViewModel: ObservableObject
{
    public DemoModel model=new();
    public double Value
    {
        get => model.value;
        set => SetProperty(ref model.value, value);
    }


    public RelayCommand<Type>? ValueCommand { get; set; }
    public RelayCommand TestCommand { get; set; }

    public DemoViewModel()
    {
        TestCommand = new(TestRun);
        ValueCommand = new(ValueRun);
    }

    private void TestRun()
    {

    }

    private void ValueRun(Type wType)
    {
        var window= (Window)System.Activator.CreateInstance(wType, new object[]{ this });
        window.Show();
        
    }
}