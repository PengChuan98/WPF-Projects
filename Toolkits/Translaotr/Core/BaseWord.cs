using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolkits.Translaotr.Core;

public struct BaseWord
{
    /// <summary>
    /// 
    /// </summary>
    public string word;

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<string, string>? interpretion;

    /// <summary>
    /// 
    /// </summary>
    public string? phoneticsUK;

    /// <summary>
    /// 
    /// </summary>
    public byte[]? voiceUK;

    /// <summary>
    /// 
    /// </summary>
    public string? phoneticsUSA;

    /// <summary>
    /// 
    /// </summary>
    public byte[]? voiceUSA;

    /// <summary>
    /// 
    /// </summary>
    public bool completed;

    /// <summary>
    /// 
    /// </summary>
    public string? reserve;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <param name="interpretion"></param>
    /// <param name="phoneticsUK"></param>
    /// <param name="voiceUK"></param>
    /// <param name="phoneticsUSA"></param>
    /// <param name="voiceUSA"></param>
    /// <param name="completed"></param>
    /// <param name="reserve"></param>
    public BaseWord(string word,
        Dictionary<string, string>? interpretion,
        string? phoneticsUK,
        byte[]? voiceUK,
        string? phoneticsUSA,
        byte[]? voiceUSA,
        bool completed,
        string? reserve)
    {
        this.word = word;
        this.interpretion = interpretion;
        this.phoneticsUK = phoneticsUK;
        this.voiceUK = voiceUK;
        this.phoneticsUSA = phoneticsUSA;
        this.voiceUSA = voiceUSA;
        this.completed = completed;
        this.reserve = reserve;
    }
}