using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

public static class MessengerHelper
{
    #region public readonly static string T令牌名字 = "消息类型+消息描述";

    // 文件打开(窗口)令牌
    public readonly static string TOpenFileDialog = "SOpenFileDialog";

    // CellViewModel
    public readonly static string TCellFontSize = "DCellFontSize";
    public readonly static string TCellStretch = "DCellFontSize";
    public readonly static string TCellRefresh = "NCellRefresh";


    // 消息（日志）令牌
    public readonly static string TInfoLog = "SInfoLog";
    public readonly static string TWarnLog = "SWarnLog";
    public readonly static string TErrorLog = "SErrorLog";

    // 测试
    public readonly static string TTestCommand = "NTest";

    #endregion

    public static void RegisterString(object recipient, string token, MessageHandler<object, string> action)
        => WeakReferenceMessenger.Default.Register<string, string>(recipient, token, action);

    /// <summary>
    /// 发送消息（字符消息）
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="token"></param>
    public static void SendString(string? msg, string token)
    {
        if (msg != null)
        {
            WeakReferenceMessenger.Default.Send(msg, token);
        }
    }

    /// <summary>
    /// 发送空字符，达到触发的目的
    /// </summary>
    /// <param name="token"></param>
    public static void SendEmptyString(string token)
        => WeakReferenceMessenger.Default.Send("", token);

    /// <summary>
    /// 通用注册，需要解包
    /// </summary>
    /// <param name="recipient"></param>
    /// <param name="token"></param>
    /// <param name="action"></param>
    public static void RegisterObject(object recipient, string token, MessageHandler<object, object> action)
        => WeakReferenceMessenger.Default.Register<object, string>(recipient, token, action);

    public static void SendDouble(double value, string token)
    {
        object temp = (object)value;
        if (temp != null)
        {
            WeakReferenceMessenger.Default.Send(temp, token);
        }
    }

    public static void SendBool(bool value, string token)
    {
        object temp = (object)value;
        if (temp != null)
        {
            WeakReferenceMessenger.Default.Send(temp, token);

        }
    }


}