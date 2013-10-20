using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
namespace FileDownloader
{
    public class DownloadTask: Task
    {
        #region Task Members
        private string url;
        private string fileName;
        private int curr = 0;
        private long size = -1;
        public DownloadTask(string url, string fileName)
        {
            this.url = url;
            this.fileName = fileName;
        }

        public bool isDone()
        {
            return false;
        }

        public void begin()
        {
            HttpWebResponse res = HttpUtil.get(url, 0, SysConfig.DOWNLOAD_UNIT);
            HttpStatusCode status = res.StatusCode;
            if (status == HttpStatusCode.OK)
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                size = res.ContentLength;
                Stream stream = res.GetResponseStream();
                byte[] buffer = new byte[SysConfig.DOWNLOAD_UNIT];
                int len;
                while((len = stream.Read(buffer, 0, SysConfig.DOWNLOAD_UNIT))>0){
                    curr+=len;
                    fileStream.Write(buffer,0,len);
                    fileStream.Flush();
                }
                fileStream.Close();
                res.Close();
            }
            else if (status == HttpStatusCode.PartialContent)
            {
                string contentRange = res.Headers["Content-Range"];
                int lenIndex = contentRange.LastIndexOf('/');
                string lenStr = contentRange.Substring(lenIndex + 1, contentRange.Length - lenIndex);// = contentRange.Substring();//bytes 0-100/12690720
                size = Int32.Parse(lenStr);

                List<DownloadRange> ranges = splitRange(SysConfig.DOWNLOAD_UNIT, size, 5);
                for (var i = 0; i < ranges.Count; i++)
                {
                    DownloadWorker worker = new DownloadWorker(url, fileName, ranges[i]);
                    Thread thread = new Thread(new ThreadStart(worker.doWork));
                    thread.Start();
                }
            }
        }

        public string percent()
        {
            if (size == -1)
                return "not start";
            return (curr / size) + "%";
        }
       


        public List<DownloadRange> splitRange(long from, long to, long n)
        {
            List<DownloadRange> list = new List<DownloadRange>();
            long delta = to - from;
            long per = delta / n;
            for (long i = 0; i < n; i++)
            {
                long from1 = from + i * per;
                long to1 = from + per;
                if (i == n - 1)
                    to1 = to;
                list.Add(new DownloadRange(from1, to1));
            }
            return list;
        }
        #endregion
    }

    class DownloadWorker
    {
        DownloadRange range;
        string url;
        string fileName;
        long current = 0;
        public DownloadWorker(string url, string fileName, DownloadRange range)
        {
            this.url = url;
            this.fileName = fileName;
            this.range = range;
        }
        public void doWork()
        {
            HttpWebResponse res = HttpUtil.get(url, range.from, range.to);
            HttpStatusCode status = res.StatusCode;
            Stream stream = res.GetResponseStream();
            byte[] buffer = new byte[SysConfig.DOWNLOAD_UNIT];
            int len;
            while((len = stream.Read(buffer, 0, SysConfig.DOWNLOAD_UNIT))>0){
                current+=len;
            }
            res.Close();
        }

        public long getCurrent()
        {
            return current;
        }
    }
}
