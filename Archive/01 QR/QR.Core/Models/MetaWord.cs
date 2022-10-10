using System;

namespace QR.Core.Models;


/// <summary>
/// 核心单词模型
/// </summary>
[Serializable]
public class MetaWord
{
    /// <summary>
    /// 单词
    /// </summary>
    public string Word { get; set; } = "";

    /// <summary>
    /// 本地释义
    /// </summary>
    public string Interpretion { get; set; } = "";

    /// <summary>
    /// 网络释义
    /// </summary>
    public string WebInterpretion { get; set; } = "";

    /// <summary>
    /// 英式读音音标
    /// </summary>
    public string PhoneticsUK { get; set; } = "";

    /// <summary>
    /// 美式读音音标
    /// </summary>
    public string PhoneticsUSA { get; set; } = "";

    /// <summary>
    /// 英式读音
    /// </summary>
    public byte[]? VoiceUK { get; set; } = null;

    /// <summary>
    /// 美式读音
    /// </summary>
    public byte[]? VoiceUSA { get; set; } = null;

    /// <summary>
    /// 标记位，是否完成翻译
    /// </summary>
    public bool IsTrans { get; set; } = false;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <param name="interpretion"></param>
    public MetaWord(string word, string interpretion)
    {
        this.Word = word;
        this.Interpretion = interpretion;
    }

    public MetaWord() { }

    public override string ToString()
    {
        string info = "";
        info += Word + "\n";
        info += IsTrans ? WebInterpretion : Interpretion;

        return info;
    }
}