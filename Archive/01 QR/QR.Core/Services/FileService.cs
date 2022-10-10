using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.Core.Services;

/// <summary>
/// 文件服务
/// 文件类型识别，文本文件的打开和保存，字节文件的打开和保存
/// 文本文件使用的是CSV文件，字节文件使用json文件
/// </summary>
public static class FileService
{

    /// <summary>
    /// 从字符串解析数据类型
    /// </summary>
    /// <param name="path"></param>
    /// <param name="t">
    /// 总共有两种数据类型
    /// 返回的后缀格式为.xxx
    /// </param>
    /// <returns></returns>
    public static bool ParseFileType(string path, out string suffix)
    {
        suffix = Helper.ValueHelper.EmptyString;

        try
        {
            if (string.IsNullOrEmpty(path)) throw new Exception("Path is null or empty.");
            suffix = System.IO.Path.GetExtension(path);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }

        return true;
    }

    //HACK 这里不另外展开写async方法，直接在视图文件里面调用的时候让他默认开个单独的线程去执行就行了
    #region 常规方法

    /// <summary>
    /// 打开文本文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static bool ReadStringFile(string path, out string content)
    {
        content = Helper.ValueHelper.EmptyString;
        
        try
        {
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
                throw new Exception("Path is invalid.");

            path = path.Trim();
            content = System.IO.File.ReadAllText(path);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }

        return true;
    }

    /// <summary>
    /// 打开字节文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool ReadByteFile(string path, out byte[] content)
    {
        content = Helper.ValueHelper.EmptyBytes;

        try
        {
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
                throw new Exception("Path is invalid.");

            path = path.Trim();
            content = System.IO.File.ReadAllBytes(path);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool SaveStringFile(string path, string content)
    {
        try
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception("Path is invalid.");

            // Hack 这里有个隐含的问题，就是保存文件的编码，之前的打开也有这个问题，这里暂时都默认是UTF-8的编码，不复杂化

            path = path.Trim();
            System.IO.File.WriteAllText(path, content);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool SaveBytesFile(string path, byte[] content)
    {
        try
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception("Path is invalid.");

            if (content == null)
                throw new Exception("Bytes of content is Null");

            path = path.Trim();
            System.IO.File.WriteAllBytes(path, content);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        return true;
    }

    #endregion
}