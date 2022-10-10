using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR.Core.Services;

/// <summary>
/// 弹窗服务
/// 文件打开和文件保存两种对话框
/// </summary>
public static class DialogService
{
    private readonly static string NoFilter = "全部文件(*.*)|*.*";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="suffix">egg.csv/word/pdf</param>
    /// <param name="isAll"></param>
    /// <returns></returns>
    public static string FilterBuilder(string suffix, bool isAll = false)
        => isAll
            ? string.Format("{0} Files(*.{1})|*.{1}|{2}", suffix.ToUpper(), suffix.ToLower(), NoFilter)
            : string.Format("{0} Files(*.{1})|*.{1}", suffix.ToUpper(), suffix.ToLower());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="suffixs"></param>
    /// <param name="isAll"></param>
    /// <returns></returns>
    public static string FilterBuilder(List<string> suffixs, bool isAll = false)
    {
        var filters = new List<string>();

        foreach (string suffix in suffixs)
        {
            filters.Add(FilterBuilder(suffix, false));
        }

        if (isAll) filters.Add(NoFilter);

        return string.Join('|', filters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="path"></param>
    /// <param name="isOpenDlg"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static bool Dialog(string filter, out string path, bool isOpenDlg = true)
    {
        path = string.Empty;
        Microsoft.Win32.FileDialog dlg = isOpenDlg
            ? new Microsoft.Win32.OpenFileDialog()
            : new Microsoft.Win32.SaveFileDialog();
        dlg.Filter = filter;

        try
        {
            if (dlg.ShowDialog() == true) path = dlg.FileName;
            else throw new Exception("Dialog exit without choose.");
        }
        catch (Exception e)
        {

            throw new Exception(e.Message, e);
        }

        return true;
    }

    public static bool OpenFileDlg(string filter, out string path)
        => Dialog(filter, out path, true);

    public static bool SaveFileDlg(string filter, out string path)
        => Dialog(filter, out path, false);
}