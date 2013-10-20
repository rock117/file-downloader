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
        public byte[] get(string url, Dictionary<string,string> headers) {

            return null;
        }

        public static void head(string url) {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";
            request.Timeout = 30000;
            request.ReadWriteTimeout = 30000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var st = response.StatusCode;
        }


        public static void download(string url)
        {
            string dir = "d:/temp";
            int index = url.LastIndexOf('/');
            string fileName = "";// url.Substring(index + 1, url.Length - index);


            HttpWebResponse res = get(url, 0, 1111111111);// get(url, 0, SysConfig.DOWNLOAD_UNIT);
            HttpStatusCode status =  res.StatusCode;
            
            string contentRange = res.Headers["Content-Range"];
            if (status == HttpStatusCode.PartialContent)
            {
                int lenIndex = contentRange.LastIndexOf('/');
                string lenStr = contentRange.Substring(lenIndex + 1, contentRange.Length - lenIndex);// = contentRange.Substring();//bytes 0-100/12690720
                int len = Int32.Parse(lenStr);
            }
            else if (status == HttpStatusCode.OK)
            {
                FileUtil.streamToFile("d:/temp/aa.apk", res.GetResponseStream());
               
            }
            else
            {

            }
        }

        public static List<Range> splitRange(int from, int to, int n)
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

      
        public static HttpWebResponse get(string url, long from, long to)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
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
           
            request.Method = "GET";           
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
