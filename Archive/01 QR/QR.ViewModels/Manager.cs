﻿using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QR.ViewModels;

public static class Manager
{
    #region public readonly static string T令牌名字 = "消息类型+消息描述";

    // 文件打开(窗口)令牌
    public readonly static string TOpenFileDialog = "SOpenFileDialog";


    // 消息（日志）令牌
    public readonly static string TInfoLog = "SInfoLog";
    public readonly static string TWarnLog = "SWarnLog";
    public readonly static string TErrorLog = "SErrorLog";
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
}