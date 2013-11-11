using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using FileDownloader.Event;
namespace FileDownloader
{
    public class Worker
    {
        string id;
        private DownloadTask task;
        private DownloadRange range;
        private MemoryStream stream;
        private long current = 0;
        private HttpUtil HttpUtil = HttpUtil.getInstance();
        private bool done;
        private int errTimes = 0;

        public delegate void WorkerStatusChanged(WorkerStatusChangedEvent e);
        public event WorkerStatusChanged onWorkerStatusChanged;
         
        public Worker(DownloadTask task, DownloadRange range)
        {
            this.task = task;
            this.range = range;
            this.done = false;
            this.stream = new MemoryStream();
            id = System.Guid.NewGuid().ToString();
        }

        public void doWork()
        {
            if (isDone())
                return;
            FileStream fs = null;
            HttpWebResponse res = null;
            try
            {
                fs = new FileStream(task.dir + task.fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                fs.Seek(range.from + current, SeekOrigin.Begin);
               // System.Diagnostics.Debug.Print(string.Format("thread {0} started.from {1},to {2}", System.Threading.Thread.CurrentThread.ManagedThreadId, range.from, range.to));
                res = HttpUtil.get(task.url, range.from + current, range.to);
                Stream stream = res.GetResponseStream();
                byte[] buffer = new byte[SysConfig.DOWNLOAD_UNIT];
                int len;
                bool pause = false;
                while ((len = stream.Read(buffer, 0, SysConfig.DOWNLOAD_UNIT)) > 0)
                {
                    
                    if (task.getStatus() != TaskStatus.Running)
                    {
                        pause = true;
                        break;
                    }
                     
                    fs.Write(buffer, 0, len);
                    fs.Flush();
                    current += len;
                   
                }
                done = !pause;
                if(done){
                  //  task.fireWorkDone(); 
                    onWorkerStatusChanged(new WorkerStatusChangedEvent(this,WorkerStatus.Working,WorkerStatus.Finished));
                }
            }
            catch (Exception e)
            {
                errTimes++;
                string id = this.task.getId();
               
                done = false;
                
                
                Logger.getLogger().error("task "+id+", worker "+this.id+" got exception "+e.Message);
                if (errTimes < 10)
                {
                    doWork();
                }
                else
                {
                    onWorkerStatusChanged(new WorkerStatusChangedEvent(this,WorkerStatus.Working,WorkerStatus.Sicked));
                }
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                if (res != null)
                {
                    res.GetResponseStream().Close();
                    res.Close();
                  
                }
            }
            
        }
        public byte[] getData() 
        {
            return this.stream.ToArray();
        }
        public bool isDone()
        {
            return done;
            
        }
        internal long getCurrent()
        {
            return this.current;
        }
    }
}
