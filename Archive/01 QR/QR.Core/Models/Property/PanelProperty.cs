namespace QR.Core.Models;

/// <summary>
/// 面板参数映射
/// </summary>
public class PanelProperty
{
    /// <summary>
    /// 单词行数
    /// </summary>
    public int Rows = 18;

    /// <summary>
    /// 单词列数
    /// </summary>
    public int Columns = 6;
    
    /// <summary>
    /// 单词组数
    /// </summary>
    public int Group = 1;

    /// <summary>
    /// 最大单词数
    /// </summary>
    public int MaxGroup = 1;

    /// <summary>
    /// 字体大小
    /// </summary>
    public double CellSize = 16;

    /// <summary>
    /// 字体格式
    /// </summary>
    public System.Windows.Media.Stretch CellStretch = System.Windows.Media.Stretch.None;
}