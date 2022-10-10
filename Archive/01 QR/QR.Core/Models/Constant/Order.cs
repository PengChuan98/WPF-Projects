namespace QR.Core.Models;


/// <summary>
/// 单词排序
/// </summary>
public enum Order
//Hack: Rename WordOrder
{
    /// <summary>
    /// 默认
    /// </summary>
    None = 0,

    /// <summary>
    /// 顺序
    /// </summary>
    Sequence = 1,

    /// <summary> 
    /// 逆序
    /// </summary>
    Reserve = 2,

    /// <summary>
    /// 随机
    /// </summary>
    Random = 3,
}