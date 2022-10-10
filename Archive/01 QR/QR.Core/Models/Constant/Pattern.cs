namespace QR.Core.Models;


/// <summary>
/// 背单词呈现方式
/// </summary>
public enum Pattern
{
    /// <summary>
    /// 都不显示，听写模式
    /// </summary>
    None = 0,

    /// <summary>
    /// 同时显示
    /// </summary>
    Bilingual = 1,

    /// <summary>
    /// 看单词回忆释义
    /// </summary>
    English = 2,

    /// <summary>
    /// 看释义回忆单词
    /// </summary>
    Chinese = 4,
}