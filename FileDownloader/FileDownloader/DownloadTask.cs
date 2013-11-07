using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace FileDownloader
{
    [Serializable]
    public class DownloadTask : Task
    {
        private object lockObj = new object();
        public string url { get; set; }
        public string dir { get; set; }
        public string fileName{get;set;}
        private long size;
        private long curr;
        private long lastPos;
        public bool pause { get; set; }
        private List<Worker> workers;
        public string id { get; set; }

        private HttpUtil HttpUtil = HttpUtil.getInstance();
        private TaskStatus status;
        public DownloadTask(string url, string dir, string fileName)
        {
            this.url = url;
            this.dir = dir+"/";
            this.fileName = fileName;     
            this.id = System.Guid.NewGuid().ToString();
            init();
        }
        private void init()
        {
            lastPos = 0;
            size = -1;
            curr = -1;
            pause = true;
            this.status = TaskStatus.BeBorn;   
        }
        public long getSize()
        {
            return size;
        }
        public long getLastPos()
        { 
            return lastPos;
        }
        public long getCurrent()
        {
            if (workers == null)
            {
                curr = 0;
                return curr;
            }

            lastPos = curr;
            long total = 0;
            foreach (Worker worker in workers)
            {
                total += worker.getCurrent();
            }
            curr = total;
            return curr;
        }
        public void stop()
        {
            this.status = TaskStatus.Runnable;
           
        }
      
        public void start()
        {
            Logger.getLogger().info("task " + this.id + " start , status:" + this.status);
            this.status = TaskStatus.Running;
           
            if (this.isDone())
            {

                return;
            }
            
            
            if (workers == null)
            {
                
                try
                {
                    calcSize();
                    //int j = 0;
                    //int i = 1 / j;
                }
                catch (Exception e)
                {
                  // MessageBox.Show(e.Message);
                    workers = null;
                    this.status = TaskStatus.BeBorn;
                    Logger.getLogger().error("task " + this.id + " err:"+e.ToString()+",task status"+this.status);
                    return;
                }
            }
            
            
                  
            for (int i=0; i<workers.Count; i++)
            {
                Worker worker = workers[i];
                Thread t = new Thread(new ThreadStart(worker.doWork));                               
                t.Start();
                
            }

           
        }

        private void calcSize() {
            this.workers = new List<Worker>();
            HttpWebResponse res = HttpUtil.get(url, 0, SysConfig.DOWNLOAD_UNIT);
            HttpStatusCode status = res.StatusCode;
            res.GetResponseStream().Close();
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
                    Console.WriteLine(range.from + "," + range.to);
                }
            }
            else
            {
               
                throw new Exception("error status:" + status);
            }
           
        }

        public bool isDone()
        {
            return this.status == TaskStatus.Finished;
           
        }

        public void fireWorkDone()
        {
            
            if (size == -1 || workers == null || workers.Count == 0)
            {
                return ;
            }

            int doNum = 0;
            foreach (Worker worker in workers)
            {
                if (worker.isDone())
                    doNum++;
            }
            if (doNum == workers.Count)
            {
                status = TaskStatus.Finished;
                TaskManager.getInstance().fireTaskDone(this);
            }
        }

        #region Task 成员

        public string getId()
        {
            return id;
        }

        #endregion

        #region Task 成员


        public TaskStatus getStatus()
        {
            lock(lockObj){
                 return status;
            }
           
        }
        public void setStatus(TaskStatus st)
        {
            lock (lockObj)
            {
                this.status = st;
            }
            
        }

        public void rebootWorker(Worker worker)
        {
            worker.doWork(); 
        }

        #endregion
    }
}
