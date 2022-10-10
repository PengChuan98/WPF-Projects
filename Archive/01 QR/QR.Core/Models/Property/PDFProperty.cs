namespace QR.Core.Models;

/// <summary>
/// PDF生成参数映射
/// </summary>
public class PDFProperty
{
    /// <summary>
    /// 页边距
    /// </summary>
    public float PageMargin = 10f;

    /// <summary>
    /// frame横向间隔
    /// </summary>
    public float HorizontalSpacing = 5f;

    /// <summary>
    /// frame纵向间隔
    /// </summary>
    public float VerticalSpacing = 5f;

    /// <summary>
    /// 基准字体大小
    /// </summary>
    public int FontSize = 8;

    /// <summary>
    /// 打钩用的空格数目
    /// </summary>
    public int BoxCount = 0;

    /// <summary>
    /// 排版格式
    /// </summary>
    public PageMode Page = PageMode.Quarter;

    /// <summary>
    /// 页面内容
    /// </summary>
    public TableMode Table = TableMode.Study;

    /// <summary>
    /// 是否随机打乱单词
    /// </summary>
    public bool IsRandom = true;

    /// <summary>
    /// 是否使用横向页面
    /// </summary>
    public bool IsLandspace = true;

    /// <summary>
    /// 是否平分当前panel中的单词（左右对开到PDF上）
    /// </summary>
    public bool IsDouble = true;
}