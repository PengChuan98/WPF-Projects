namespace QR.Core.Models;

/// <summary>
/// 单词记忆设置参数镜像
/// </summary>
public class WordProperty
{
    /// <summary>
    /// 单词顺序
    /// </summary>
    public Order Order = Order.None;

    /// <summary>
    /// 声音源
    /// </summary>
    public Voice Voice = Voice.USA;

    /// <summary>
    /// 释义源
    /// </summary>
    public Source Source = Source.Web;

    /// <summary>
    /// 背单词模式
    /// </summary>
    public Pattern Pattern = Pattern.English;

    public override string ToString()
        => string.Join("\n", Order, Voice, Source, Pattern);
}
