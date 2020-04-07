using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamworkClient.Config;
using TeamworkClient.Controller;
using TeamworkClient.Helper;
using TeamworkClient.Models;
using TeamworkClient.Templates;
using TeamworkClient.View;

namespace TeamworkClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMainMenuAsync();
            NetWorkCheck();
        }

        /// <summary>
        /// 网络检查
        /// </summary>
        private void NetWorkCheck()
        {
            NetWorkChecker.check(NetConfig.HOSTNAME);
            fmMainView.Source = new Uri("NetWorkErrorPage.xaml", UriKind.Relative);
        }

        /// <summary>
        /// 初始化导航菜单
        /// </summary>
        private async void InitializeMainMenuAsync()
        {
            var menuController = new MyMenuController();
            List<MyMenu> myMenus = await menuController.LoadListFromUrlAsync("");
            lbMainMenu.ItemsSource = myMenus;
            lbMainMenu.SelectionChanged += LbMainMenuSelectionChanged;
        }

        /// <summary>
        /// 导航菜单按钮点击事件，切换Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LbMainMenuSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuListBox = sender as ListBox;
            var selectedItem = menuListBox.SelectedItem as MyMenu;
            var currentPage = fmMainView.Content as BasePage;
            // 排除主页，默认已经在主页的情况下点击主页，不执行动画
            if (!currentPage.GetType().Equals(typeof(HomePage)))
                await currentPage.AnimateOut();
            fmMainView.Source = new Uri(selectedItem.Route, UriKind.Relative);
        }

        /// <summary>
        /// 程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// 全屏显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxSize(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinSize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        /// <summary>
        /// 鼠标拖拽移动窗体
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }


    }
}
