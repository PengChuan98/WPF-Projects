namespace QR.Core.Models;

/// <summary>
/// 释义和语音模式
/// </summary>
public enum Source
{
    /// <summary>
    /// 使用本地的单词和语音服务
    /// </summary>
    Native = 0,

    /// <summary>
    /// 使用网上的释义和语音
    /// </summary>
    Web = 1,
}