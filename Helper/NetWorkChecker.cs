using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace TeamworkClient.Helper
{
    class NetWorkChecker
    {
        /// <summary>
        /// 检查网络状态
        /// </summary>
        /// <param name="url">目标主机地址</param>
        /// <returns></returns>
        public static bool check(string url)
        {
            Ping ping = new Ping();
            bool netStatus = false;
            try
            {
                netStatus = ping.Send(url).Status != IPStatus.Success; 
            }
            finally
            {
                netStatus = false;
            }
            return netStatus;
        }
    }
}
