using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolkits.Helpers;

/// <summary>
/// 对象工具集
/// </summary>
/// <typeparam name="T">对象数据类型</typeparam>
public static class ClassHelper<T>
    where T : class, new()
{
    /// <summary>
    /// 复制所有对象的字段数据
    /// </summary>
    /// <param name="src">待复制对象</param>
    /// <param name="dst">复制对象</param>
    /// <returns></returns>
    public static bool CopyAllFields(T src, T dst)
    {
        if (src == null || dst == null) return false;

        var properties = src.GetType().GetFields();

        for (int i = 0; i < properties.Length; i++)
        {
            properties[i].SetValue(src, properties[i].GetValue(dst));
        }

        return true;

    }
}