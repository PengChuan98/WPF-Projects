using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolkits.Translaotr.Core;

public abstract class BaseTranslator
{
    /// <summary>
    /// 下载进度
    /// </summary>
    public int DownloadProgress { get; set; } = 0;

    /// <summary>
    /// 
    /// </summary>
    public bool IsCompleted { get; set; } = false;

    public string? LastErrorMessage = null;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    protected abstract string GenerateURL(string word);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="html"></param>
    /// <param name="mw"></param>
    /// <returns></returns>
    protected abstract bool Parse(string word, string html, out BaseWord? mw, ref string? error);

    /// <summary>
    /// 下载单个单词信息
    /// </summary>
    /// <param name="word"></param>
    /// <param name="mw"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual bool Trans(string word, out BaseWord? mw)
    {
        IsCompleted = false;
        string url = GenerateURL(word);
        mw = null;

        try
        {
            string html = Net.Downloader.DownloadHTML(url);
            if (Parse(word, html, out mw, ref LastErrorMessage))
            {
                IsCompleted = true;
                return true;
            }
            else
            {
                throw new Exception(LastErrorMessage);
            }

        }
        catch (Exception e)
        {
            LastErrorMessage = e.ToString();
            return false;
        }
    }
}