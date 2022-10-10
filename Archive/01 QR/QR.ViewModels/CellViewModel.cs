using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using QR.Core.Models;
using Toolkits.Media;

namespace QR.ViewModels;

public class CellViewModel : ObservableObject
{
    public CellViewModel(MetaWord word,WordProperty proterty)
    {
        Meta = word;
        MetaProperty = proterty;

        timer = new DispatcherTimer(DispatcherPriority.Render)
        {
            Interval = TimeSpan.FromSeconds(SwitchInterval)
        };

        timer.Tick += (s, e) => 
        {
            ShowFront();
            timer.Stop();
        };
    }


    DispatcherTimer timer;

    /// <summary>
    /// 单词切换之后还原需要的间隔
    /// <para>单位秒</para>
    /// </summary>
    public double SwitchInterval { get; set; } = 2;

    /// <summary>
    /// 数据对象
    /// </summary>
    public MetaWord Meta { get; set; } = new();

    /// <summary>
    /// 配置对象
    /// </summary>
    public WordProperty MetaProperty { get; set; } = new();

    /// <summary>
    /// 单词
    /// </summary>
    protected string Word { get => Meta.Word; }

    /// <summary>
    /// 本地释义
    /// </summary>
    protected string NativeInterpretion { get => Meta.Interpretion; }

    /// <summary>
    /// 网络释义
    /// </summary>
    protected string WebInterpretion { get => Meta.IsTrans ? Meta.WebInterpretion : Meta.Interpretion; }

    /// <summary>
    /// 能获取的有效释义
    /// </summary>
    protected string Interpretioin { get => MetaProperty.Source.Equals(Source.Native) ? NativeInterpretion : WebInterpretion; }

    /// <summary>
    /// 英语+中文
    /// </summary>
    protected string MetaInfo { get => string.Join(" ", Word, Interpretioin); }

    private string _show = "";

    /// <summary>
    /// 当前界面渲染的内容
    /// </summary>
    public string Show
    {
        get => _show;
        set => SetProperty(ref _show, value);
    }

    /// <summary>
    /// 显示正面信息
    /// </summary>
    public virtual void ShowFront()
    {
        switch (MetaProperty.Pattern)
        {
            case Pattern.None:
                Show = "";
                break;
            case Pattern.Bilingual:
                Show = MetaInfo;
                break;
            case Pattern.English:
                Show = Word;
                break;
            case Pattern.Chinese:
                Show = Interpretioin;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 显示反面信息
    /// </summary>
    public virtual void ShowBack()
    {
        switch (MetaProperty.Pattern)
        {
            case Pattern.None:
                Show = MetaInfo;
                break;
            case Pattern.Bilingual:
                Show = MetaInfo;
                break;
            case Pattern.English:
                Show = Interpretioin;
                break;
            case Pattern.Chinese:
                Show = Word;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 朗读单词
    /// </summary>
    public virtual void Speak()
    {
        switch (MetaProperty.Voice)
        {
            case Voice.Local:
                Speaker.ReadStringAsync(Word);
                break;
            case Voice.USA:
                if (Meta.VoiceUSA != null)
                {
                    Speaker.ReadBytesAsync(Meta.VoiceUSA);
                }
                else
                {
                    Speaker.ReadStringAsync(Word);
                }
                break;
            case Voice.UK:
                if (Meta.VoiceUK != null)
                {
                    Speaker.ReadBytesAsync(Meta.VoiceUK);
                }
                else
                {
                    Speaker.ReadStringAsync(Word);
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 恢复初始状态
    /// </summary>
    public void Reset()
    {
        timer?.Stop();
        ShowFront();
    }

    /// <summary>
    /// 翻个面瞅一下
    /// </summary>
    public void Glance()
    {
        if (!timer.IsEnabled)
        {
            ShowBack();
            timer.Start();
        }
        else // 定时器已经启动了
        {
            ShowFront();
            timer.Stop();
        }
    }

    public override string ToString() => Meta.ToString();
}