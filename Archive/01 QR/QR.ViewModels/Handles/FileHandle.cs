using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QR.Core.Models;
using QR.Core.Services;
using QR.Core.Helper;

namespace QR.ViewModels.Handles;

public static class FileHandle
{





    /// <summary>
    /// 打开CSV文件窗口
    /// </summary>
    /// <param name="csvPath"></param>
    /// <param name="words"></param>
    public static void ReadCSVFileWithDialog(out string csvPath, out List<MetaWord> words)
    {
        csvPath = ValueHelper.EmptyString;
        words = new();

        try
        {
            DialogService.OpenFileDlg(DialogService.FilterBuilder("csv", true), out csvPath);

            if (FileService.ReadStringFile(csvPath, out string content) && WordService.FromCSV(content, out words))
            {
                MessengerHelper.SendString(string.Format("加载了{0}个单词 . 加载地址 : {1}", words.Count, csvPath), MessengerHelper.TInfoLog);
                MessengerHelper.SendEmptyString(MessengerHelper.TLoadWordsSuccess);
            }
        }
        catch (Exception exception)
        {

            MessengerHelper.SendString(exception.Message, MessengerHelper.TErrorLog);
        }
    }

    /// <summary>
    /// 打开words文件
    /// </summary>
    /// <param name="wordsPath"></param>
    /// <param name="words"></param>
    public static void ReadWordsFileWithDialog(out string wordsPath, out List<MetaWord> words)
    {
        wordsPath = ValueHelper.EmptyString;
        words = new();

        try
        {
            DialogService.OpenFileDlg(DialogService.FilterBuilder("words", true), out wordsPath);

            if (FileService.ReadByteFile(wordsPath, out var content) && WordService.FromBytes(content, out words))
            {
                MessengerHelper.SendString(string.Format("加载了{0}个单词 . 加载地址 : {1}", words.Count, wordsPath), MessengerHelper.TInfoLog);
                MessengerHelper.SendEmptyString(MessengerHelper.TLoadWordsSuccess);
            }
        }
        catch (Exception exception)
        {
            MessengerHelper.SendString(exception.Message, MessengerHelper.TErrorLog);
        }
    }

    public static void SaveCSVFileWithDialog(List<MetaWord> words, out string csvPath)
    {
        csvPath = ValueHelper.EmptyString;
        try
        {
            if (words == null || words.Count <= 0) throw new Exception("The words saved with the tape is null or empty.");

            DialogService.SaveFileDlg(DialogService.FilterBuilder("csv", true), out csvPath);

            if (WordService.ToCSV(words, out var content) && FileService.SaveStringFile(csvPath, content))
            {
                MessengerHelper.SendString(string.Format("保存CSV成功. 保存地址 : {0}", csvPath), MessengerHelper.TInfoLog);
            }
            else
            {
                throw new Exception("保存为CSV文件失败.");
            }
        }
        catch (Exception exception)
        {

            MessengerHelper.SendString(exception.Message, MessengerHelper.TErrorLog);
        }
    }

    public static void SaveWordsFileWithDialog(List<MetaWord> words, out string wordsPath)
    {
        wordsPath = ValueHelper.EmptyString;
        try
        {
            if (words == null || words.Count <= 0) throw new Exception("The words saved with the tape is null or empty.");

            DialogService.SaveFileDlg(DialogService.FilterBuilder("words", true), out wordsPath);

            if (WordService.ToBytes(words, out var content) && FileService.SaveBytesFile(wordsPath, content))
            {
                MessengerHelper.SendString(string.Format("保存Words成功. 保存地址 : {0}", wordsPath), MessengerHelper.TInfoLog);
            }
            else
            {
                throw new Exception("保存为Words文件失败.");
            }
        }
        catch (Exception exception)
        {

            MessengerHelper.SendString(exception.Message, MessengerHelper.TErrorLog);
        }
    }

}
