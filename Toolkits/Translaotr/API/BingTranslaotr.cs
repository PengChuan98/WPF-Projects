using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Toolkits.Translaotr.Core;

namespace Toolkits.Translaotr.API;

public class BingTranslaotr : BaseTranslator
{
    protected override string GenerateURL(string word) => string.Format("https://cn.bing.com/dict/search?q={0}", word);

    protected override bool Parse(string word, string html, out BaseWord? mw, ref string? error)
    {
        Dictionary<string, string>? interpertion = new();

        // 这两个使用null即可
        string? phoneticsUK = null;
        string? phoneticsUSA = null;

        byte[]? voiceUK = null;
        byte[]? voiceUSA = null;

        bool completed = true;
        string? reserve = null;

        try
        {
            HtmlDocument builder = new();
            builder.LoadHtml(html);

            HtmlNode mainNode = builder.DocumentNode.SelectSingleNode("//*/div[@class='qdef']");
            HtmlNode headNode = mainNode.SelectSingleNode("div[@class=\"hd_area\"]");

            HtmlNodeCollection interpretionCollection = mainNode.SelectNodes("ul/li");

            // 解析解释dict
            foreach (HtmlNode node in interpretionCollection)
            {
                string k = node.SelectSingleNode("span[@class=\"pos\"]|span[@class=\"pos web\"]").InnerText;
                k = k.Contains("网络") ? "web" : k;
                string v = node.SelectSingleNode("span[@class=\"def b_regtxt\"]/span").InnerText;
                interpertion[k] = v;
            }

            HtmlNode speakerNode = builder.DocumentNode.SelectSingleNode("//*/div[@class='hd_p1_1']");

            Regex voiceUrlRegex = new(@"http[s]?://(?:[a-zA-Z]|[0-9]|[$-_@.&+]|[!*\(\),]|(?:%[0-9a-fA-F][0-9a-fA-F]))+\.mp3");
            HtmlNodeCollection voiceNode = speakerNode.SelectNodes("div[@class=\"hd_tf\"]");
            var voice1 = voiceUrlRegex.Match(voiceNode[0].InnerHtml).Value;
            var voice2 = voiceUrlRegex.Match(voiceNode[1].InnerHtml).Value;

            voiceUK = Net.Downloader.DownloadBytes(voice2);
            voiceUSA = Net.Downloader.DownloadBytes(voice1);
        }
        catch (NullReferenceException e)
        {
            completed = false;
            throw new Exception(String.Format("{0}下载失败", word), e);
        }
        catch(Exception e)
        {
            completed = false;
            throw new Exception(e.Message, e);
        }
        finally
        {
            mw = new(word, interpertion, phoneticsUK, voiceUK, phoneticsUSA, voiceUSA, completed, reserve);
        }

        return completed;
    }
}