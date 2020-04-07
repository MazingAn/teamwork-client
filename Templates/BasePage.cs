using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TeamworkClient.Animations;

namespace TeamworkClient.Templates
{
    public class BasePage : Page
    {
        #region 动画参数
        
        /// <summary>
        /// 页面第一次加载的时动画
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// 页面被隐藏时候的动画
        /// </summary>
        public PageAnimation PageLoadedAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;


        /// <summary>
        /// 动画执行持续的时间
        /// </summary>
        public float SlideSeconds { get; set; } = 1.0f;


        #endregion

        #region 构造函数

        public BasePage()
        {
            // 加载之前隐藏页面
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
            // 监听页面加载
            this.Loaded += BasePageLoaded;
        }

        #endregion


        #region 加载/隐藏 动画
        /// <summary>
        /// 当页面被加载的时候，调用对应动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePageLoaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }
        #endregion

        /// <summary>
        /// 页面进入动画
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    var sb = new Storyboard();
                    var slideAnimation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(this.SlideSeconds)),
                        From = new Thickness(1,1,1,1),
                        To = new Thickness(28,14,28,14),
                    };
                    Storyboard.SetTargetProperty(slideAnimation, new PropertyPath(BasePage.MarginProperty));
                    sb.Begin(this);
                    this.Visibility = Visibility.Visible;
                    await Task.Delay((int)(this.SlideSeconds * 1000));
                    break;
            }
        }

    }
}
