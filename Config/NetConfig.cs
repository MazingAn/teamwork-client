using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkClient.Config
{
    class NetConfig
    {
        public static readonly string HOSTNAME = "10.211.55.2";
        public static readonly int PORT = 8080;

        public static string UrlJoin(string path, string param)
        {
            // var uri = new UriBuilder("http", HOSTNAME, PORT, path, param);
            // return uri.ToString();

            return "http://" + HOSTNAME + ":" + PORT + "/" + path + "/" + param;
        }

    }
}
