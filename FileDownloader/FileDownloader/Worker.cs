using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
namespace FileDownloader
{
    public class Worker
    {
        private DownloadTask task;
        private DownloadRange range;
        private MemoryStream stream;
        private long current = 0;
        public Worker(DownloadTask task, DownloadRange range)
        {
            this.task = task;
            this.range = range;
            this.stream = new MemoryStream();
        }

        public void doWork()
        {
            if (isDone())
                return;
            FileStream fs = new FileStream(SysConfig.DOWNLOAD_DIR + task.fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            fs.Seek(range.from+current, SeekOrigin.Begin);
            System.Diagnostics.Debug.Print(string.Format("thread {0} started.from {1},to {2}", System.Threading.Thread.CurrentThread.ManagedThreadId, range.from, range.to));
            HttpWebResponse res = HttpUtil.get(task.url, range.from+current, range.to);
            Stream stream = res.GetResponseStream();
            byte[] buffer = new byte[SysConfig.DOWNLOAD_UNIT];
            int len;
            while ((len = stream.Read(buffer, 0, SysConfig.DOWNLOAD_UNIT)) > 0)
            {
                if (task.isPause())
                    break;
                fs.Write(buffer, 0, len);
                fs.Flush();
                current += len;
            }
            res.Close();
            System.Diagnostics.Debug.Print(string.Format("thread {0} end.", System.Threading.Thread.CurrentThread.ManagedThreadId));
            fs.Close();

        }
        public byte[] getData() 
        {
            return this.stream.ToArray();
        }
        public bool isDone()
        {
            return current != 0 && current == range.to;
        }
        internal long getCurrent()
        {
            return this.current;
        }
    }
}
