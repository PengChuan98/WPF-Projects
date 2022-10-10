using Microsoft.Toolkit.Mvvm.ComponentModel;
using QR.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Toolkits.Media;

namespace QR.ViewModels;

public class CellViewModel: ObservableObject
{
    #region 初始化
    DispatcherTimer timer;

    /// <summary>
    /// 单词切换之后还原需要的间隔
    /// <para>单位秒</para>
    /// </summary>
    public double Interval { get; set; } = 2;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="meta">单词对象</param>
    /// <param name="property">参数对象</param>
    public CellViewModel(MetaWord meta, WordProperty property)
    {
        Meta = meta;
        MetaProperty = property;

        timer = new DispatcherTimer(DispatcherPriority.Render)
        {
            Interval = TimeSpan.FromSeconds(Interval)
        };

        timer.Tick += ShowTimerTick;
    }


    /// <summary>
    /// 定时还原切换过的显示内容
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ShowTimerTick(object? sender, EventArgs e)
    {
        ShowFront();
        timer.Stop();
    }
    #endregion

    #region 通知属性

    private string _show = "";

    /// <summary>
    /// 当前界面渲染的内容
    /// </summary>
    public string Show
    {
        get => _show;
        set => SetProperty(ref _show, value);
    }
    #endregion

    #region 属性

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

    #endregion

    #region 方法

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
    public void Stop()
    {
        timer?.Stop();
        ShowFront();
    }

    #endregion

    #region 动作
    /// <summary>
    /// 单击切换中英文
    /// Interval之后自动回默认结果
    /// </summary>
    public void LeftButtonClick()
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

    /// <summary>
    /// 朗读单词
    /// </summary>
    public void RightButtonClick()
        => Speak();

    /// <summary>
    /// 编辑当前内容
    /// </summary>
    public void MiddleButtonClick()
    {
        if (Keyboard.IsKeyDown(Key.LeftCtrl))
        {
            //EditorViewModel vm = new(this.Meta);
            //Views.EditorWindow editor = new(vm);
            //editor.ShowDialog();
        }
    }
    #endregion

    public override string ToString() => Meta.ToString();
}