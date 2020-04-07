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
using TeamworkClient.Controller;
using TeamworkClient.Models;
using TeamworkClient.Templates;

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
        }

        private async void InitializeMainMenuAsync()
        {
            var menuController = new MyMenuController();
            List<MyMenu> myMenus = await menuController.LoadListFromUrlAsync("");
            lbMainMenu.ItemsSource = myMenus;
            lbMainMenu.SelectionChanged += LbMainMenuSelectionChanged;
        }

        private void LbMainMenuSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuListBox = sender as ListBox;
            var selectedItem = menuListBox.SelectedItem as MyMenu;

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaxSize(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void MinSize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }


    }
}
