namespace QR.Core.Models;

/// <summary>
/// Menu中设置参数映射
/// <para>CoreConfig.settings的部分映射</para>
/// </summary>
public class ConfigProperty
{
    /// <summary>
    /// 启动时加载最后一次配置
    /// </summary>
    public bool IsStartWithLast = true;

    /// <summary>
    /// Group改变时自动从网络下载字典
    /// </summary>
    public bool IsAutoDownload = false;

    /// <summary>
    /// 配置文件变动时保存更改
    /// </summary>
    public bool IsAutoSaveConfig = true;

    /// <summary>
    /// 在下载，手动修改等对单词对象修改的时候调用，覆盖打开文件
    /// </summary>
    public bool IsAutoSaveFile = true;

    /// <summary>
    /// 退出时自动保存配置
    /// </summary>
    public bool IsSaveConfigWithExit = true;

    /// <summary>
    /// 退出时自动保存文件
    /// </summary>
    public bool IsSaveFileWithExit = true;

    /// <summary>
    /// 窗体是否置顶
    /// </summary>
    public bool IsTopmost = true;

    /// <summary>
    /// 是否显示状态栏
    /// </summary>
    public bool IsShowStatusBar = true;

    /// <summary>
    /// 窗体主题
    /// </summary>
    public Theme WindowTheme = Theme.Light;

}    