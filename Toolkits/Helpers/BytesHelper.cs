using System;

namespace Toolkits.Helpers;

public static class BytesHelper
{
    #region converter

    /// <summary>
    /// 字符串转换成二进制文件
    /// </summary>
    /// <param name="str"></param>
    /// <param name="bytes"></param>
    /// <returns>
    /// true - bytes不为空
    /// </returns>
    /// <exception cref="Exception"></exception>
    public static void FromString(string str, out byte[]? bytes)
    {
        bytes = null;
        if (string.IsNullOrEmpty(str)) throw new ArgumentException("输入字符为空引用或空字符");

        try
        {
            bytes = System.Text.Encoding.UTF8.GetBytes(str);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
    }

    /// <summary>
    /// bytes转换成字符串
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="str"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static void ToString(byte[] bytes, out string? str)
    {
        str = null;

        if (bytes == null) throw new ArgumentException("输入二进制数据为空引用");
        
        try
        {
            str = System.Text.Encoding.UTF8.GetString(bytes);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message,e);
        }
    }
    #endregion

    #region 压缩解压缩
    /// <summary>
    /// 压缩二进制文件
    /// </summary>
    /// <param name="data"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static void Compress(byte[] data, out byte[] result)
    {
        result = new byte[0];

        if (data == null) throw new ArgumentException("输入二进制数据为空引用");
        
        try
        {
            System.IO.MemoryStream ms = new();
            System.IO.Compression.GZipStream compressedzipStream
                = new(ms, System.IO.Compression.CompressionMode.Compress, true);
            compressedzipStream.Write(data, 0, data.Length);
            compressedzipStream.Close();
            result = ms.ToArray();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
    }

    /// <summary>
    /// 解压文件
    /// </summary>
    /// <param name="data"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static void Decompress(byte[] data, out byte[]? result)
    {
        result = null;
        if (data == null) throw new Exception("输入二进制数据为空引用");
        
        try
        {
            System.IO.MemoryStream ms = new(data);
            System.IO.Compression.GZipStream compressedzipStream
                = new(ms, System.IO.Compression.CompressionMode.Decompress);
            System.IO.MemoryStream outBuffer = new();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                else
                    outBuffer.Write(block, 0, bytesRead);
            }
            compressedzipStream.Close();
            result = outBuffer.ToArray();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
    }

    #endregion
}