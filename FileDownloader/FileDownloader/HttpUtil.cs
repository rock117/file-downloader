using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
 
namespace FileDownloader
{
    public class HttpUtil
    {
        private static HttpUtil instance = new HttpUtil();
        private HttpUtil()
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;
        }



        public static HttpUtil getInstance() {
            return instance;
        }
       


       

        public  List<Range> splitRange(int from, int to, int n)
        {
            List<Range> list = new List<Range>();
            int delta = to - from;
            int per = delta / n;
            for (int i = 0; i < n; i++)
            {
                int from1 = from + i * per;
                int to1 = from + per;
                if (i == n - 1)
                    to1 = to;
                list.Add(new Range(from1, to1));
            }
            return list;
        }

      
        public  HttpWebResponse get(string url, long from, long to)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ServicePoint.ConnectionLimit = Int32.MaxValue;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:25.0) Gecko/20100101 Firefox/25.0";
            //System.Net.WebProxy proxy = new WebProxy("127.0.0.1", 8888);
           // request.Proxy = proxy;
            if (from != null && to != null)
            {
                request.AddRange(from, to);
            }
            else if (from != null && to == null)
            {
                request.AddRange(from);
            }
            else if (from == null && to != null)
            {
                request.AddRange(to * (-1));
            }
            //request.KeepAlive = false;
            request.Timeout = 30 * 1000;
            request.ReadWriteTimeout = 50 * 1000;
            request.Method = "GET";           
           // System.Diagnostics.Debug.Print(
            
            return (HttpWebResponse)request.GetResponse();
        }

    }
    public class Range
    {
        public int from;
        public int to;
        public Range(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

    }
}
