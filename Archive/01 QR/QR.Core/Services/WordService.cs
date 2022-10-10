using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QR.Core.Models;
using Toolkits.Helpers;

namespace QR.Core.Services;

/// <summary>
/// 单词对象操作方法
/// 打开文件转成word对象，word对象转成文件
/// </summary>
public static class WordService
{
    /// <summary>
    /// 从CSV数据转成MetaWord数据集
    /// 从规定的CSV格式文件转换成list对象集合
    /// 约定形式为xxxx,yyyy.....
    /// </summary>
    /// <param name="content">CSV文本内容</param>
    /// <param name="collection">数据集</param>
    /// <returns></returns>
    public static bool FromCSV(string content, out List<MetaWord> collection)
    {
        collection = new();
        try
        {
            string[] lines = content.Split(Environment.NewLine.ToArray());
            int lineCount = lines.Length;

            for (int i = 0; i < lineCount; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                string[] cell = line.Split(new char[] { ',' }, 2);

                // 不符合规范的结果
                if (cell.Length != 2) continue;

                collection.Add(new(cell[0], cell[1]));
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }

        return true;
    }

    /// <summary>
    /// 将数据集内容转成CSV文本
    /// 从list对象集合转换成规定的CSV格式文件
    /// 约定形式为xxxx,yyyy.....
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static bool ToCSV(List<MetaWord> collection, out string content)
    {
        content = Helper.ValueHelper.EmptyString;
        try
        {
            List<string> line = new List<string>();
            foreach (MetaWord word in collection)
            {
                line.Add(word.Word + "," + word.Interpretion);
            }

            content = string.Join('\n', line);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }

        return true;
    }

    /// <summary>
    /// Bytes转成数据集
    /// bytes->decompress->deserialize->json-collection
    /// 解压二进制文件 -> 二进制转成字符串 -> 字符串反序列化 -> 反序列化后的对象放入集合
    /// <para>使用了解压算法</para>
    /// </summary>
    /// <param name="content"></param>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static bool FromBytes(byte[] content, out List<MetaWord> collection)
    {
        collection = new();

        try
        {
            BytesHelper.Decompress(content, out byte[]? decompress);
            if (decompress == null) throw new Exception("解压缩失败");

            BytesHelper.ToString(decompress, out string? serialize);
            if (serialize == null) throw new Exception("二进制转字符串失败");

            ListHelper<MetaWord>.Deserialize(serialize, out collection);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }

        return true;
    }

    /// <summary>
    /// 数据集转Bytes
    /// collection->json->serialize->compress->bytes
    /// 序列化为字符串 -> 字符串转成二进制文件 -> 压缩二进制文件
    /// <para>使用了压缩算法</para>
    /// </summary>
    /// <param name="collection">数据集</param>
    /// <param name="content">二进制内容</param>
    /// <returns></returns>
    public static bool ToBytes(List<MetaWord> collection, out byte[] content)
    {
        content = Helper.ValueHelper.EmptyBytes;
        // 序列化为字符串 -> 字符串转成二进制文件 -> 压缩二进制文件
        try
        {
            ListHelper<MetaWord>.Serialize(collection, out string? serialize);
            if (serialize == null) throw new Exception("序列化失败");

            BytesHelper.FromString(serialize, out byte[]? bytes);
            if (bytes == null) throw new Exception("字符串转二进制失败");

            BytesHelper.Compress(bytes, out content);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }

        return true;
    }
}