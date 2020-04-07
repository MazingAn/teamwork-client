using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TeamworkClient.Templates
{

    class MyMenuPanel : StackPanel
    {

        public static DependencyProperty RouteProperty =
            DependencyProperty.Register("Route", typeof(string), typeof(MyMenuPanel));
        public static DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(MyMenuPanel));

        public string Route { get; set; }
        public string Content { get; set; }
    }
}
