using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.Core.Models;

/// <summary>
/// HACK：这个地方可以删除，使用之前Constant中的Pattern
/// </summary>
public enum TableMode
{
    /// <summary>
    /// 整张纸包含中英文
    /// </summary>
    Study = 0,

    /// <summary>
    /// 整张纸只有英语
    /// </summary>
    Review = 1,
}