using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
namespace FileDownloader
{
    public class DownloadTask : Task
    {

        public string url { get; set; }
        public string fileName{get;set;}
        private long size;
        private long curr;
        public bool pause { get; set; }
        private List<Worker> workers;

        public static ManualResetEvent[] manualResetEvents;
       
        public DownloadTask(string url, string fileName)
        {
            this.url = url;
            this.fileName = fileName;
            this.workers = new List<Worker>();
            init();
        }
        private void init()
        {
            size = -1;
            curr = -1;
            pause = false;
        }
        public long getSize()
        {
            return size;
        }
        public long getCurrent()
        {
            return curr;
        }
        public void stop()
        {
            this.pause = true;
        }
        public void start()
        {
            this.pause = false;
            calcSize();
            List<Thread> tlist = new List<Thread>();
            Dictionary<string, Worker> ws = new Dictionary<string, Worker>();
            for (int i=0; i<workers.Count; i++)
            {
                Worker worker = workers[i];
                Thread t = new Thread(new ThreadStart(worker.doWork));
                tlist.Add(t);
                 
                t.Start();
                ws.Add(i + "", worker);
            }

            //for (int i = 0; i < workers.Count; i++)
            //{
            //    if (i < 2)
            //        tlist[i].Join();
            //}
            //FileStream fs = new FileStream(SysConfig.DOWNLOAD_DIR + fileName, FileMode.OpenOrCreate);
            //for (int i = 0; i < workers.Count; i++)
            //{
            //    Worker w = ws[i + ""];
            //    byte[] data = w.getData();
            //    fs.Write(data, 0, data.Length);
            //}
            //fs.Close();
        }

        private void calcSize() {
            HttpWebResponse res = HttpUtil.get(url, 0, SysConfig.DOWNLOAD_UNIT);
            HttpStatusCode status = res.StatusCode;
            res.Close();
            if (status == HttpStatusCode.OK)
            {
                this.size = res.ContentLength;
                workers.Add(new Worker(this, new DownloadRange(0, size-1)));
            }
            else if (status == HttpStatusCode.PartialContent)
            {
                string contentRange = res.Headers["Content-Range"];
                int lenIndex = contentRange.LastIndexOf('/');
                string lenStr = contentRange.Substring(lenIndex + 1, contentRange.Length - 1 - lenIndex);// = contentRange.Substring();//bytes 0-100/12690720
                this.size = Int32.Parse(lenStr);
                List<DownloadRange> ranges = DownloadRange.splitRange(0, size, SysConfig.WORKERS_NUM);
                foreach (DownloadRange range in ranges)
                {
                    workers.Add(new Worker(this, range));
                }
            }
            else
            {
                throw new Exception("error occur");
            }
           
        }

        public bool isDone()
        {
            return curr != -1 && curr == size;
        }
    }
}
