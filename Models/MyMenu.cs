using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkClient.Models
{
    class MyMenu
    {
        /// <summary>
        /// 菜单显示名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 菜单路由目的地址（Page页面）
        /// </summary>
        public string Route { get; set; }
        
        /// <summary>
        /// 菜单图表类型
        /// </summary>
        public string IconType { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="route">路径</param>
        /// <param name="iconType">图标类型</param>
        public MyMenu(string name, string route, string iconType)
        {
            Name = name;
            Route = route;
            IconType = iconType;
        }
    }
}
