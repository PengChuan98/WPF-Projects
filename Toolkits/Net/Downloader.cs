using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Toolkits.Net;

public class Downloader
{
    /// <summary>
    /// 
    /// </summary>
    public static readonly HttpClient Client;

    /// <summary>
    /// 
    /// </summary>
    static Downloader()
    {
        //var socketsHandler = new SocketsHttpHandler
        //{
        //    PooledConnectionLifetime = TimeSpan.FromMinutes(2)
        //};
        Client = new HttpClient();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static async Task<string> DownloadHTMLAsync(string url)
    {
        string content = "";
        try
        {
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            content = await response.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        return content;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static string DownloadHTML(string url)
    {
        string content = "";
        try
        {
            var response = Client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            content = response.Content.ReadAsStringAsync().Result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        return content;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static async Task<byte[]?> DownloadBytesAsync(string url)
    {
        byte[]? content = null;
        try
        {
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            content = await response.Content.ReadAsByteArrayAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        return content;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static byte[]? DownloadBytes(string url)
    {
        byte[]? content = null;
        try
        {
            var response = Client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            content = response.Content.ReadAsByteArrayAsync().Result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        return content;
    }


}
