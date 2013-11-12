using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FileDownloader.Event;
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

     
        private TaskStatus status;

        public delegate void TaskStatusChanged(TaskStatusChangedEvent e);
        public event TaskStatusChanged onTaskStatusChanged;

        private int errNums = 0;
        private DateTime _finishedTime;
        public DownloadTask(string url, string dir, string fileName)
        {
            this.url = url;
            this.dir = dir+"/";
            this.fileName = fileName;     
            this.id = System.Guid.NewGuid().ToString();
            init();
        }
        public void OnWorkerStatusChanged(WorkerStatusChangedEvent e)
        {
            if (size == -1 || workers == null || workers.Count == 0)
            {
                return;
            }
            Worker worker = e.worker;
            if(e.to == WorkerStatus.Finished){
                int doNum = 0;
                foreach (Worker w in workers)
                {
                    if (w.isDone())
                        doNum++;
                }
                if (doNum == workers.Count)
                {
                     onTaskStatusChanged(new TaskStatusChangedEvent(this,this.status,TaskStatus.Finished));
                }
            }
            else if (e.to == WorkerStatus.Sicked)
            {
                errNums++;
                TaskStatus to = errNums<10?TaskStatus.Waiting:TaskStatus.Dead;
                onTaskStatusChanged(new TaskStatusChangedEvent(this, this.status, to));
            }




        }
        private void init()
        {
            lastPos = 0;
            size = -1;
            curr = -1;
            errNums = 0;
            
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
           // this.status = TaskStatus.Runnable;
            throw new Exception("err stop");
        }
      
        public void start()
        {
            Logger.getLogger().info("task " + this.id + " start , status:" + this.status);
            if (workers == null)
            {
                
                try
                {
                    calcSize();         
                }
                catch (Exception e)
                {
                    errNums++;
                    workers = null;
                    Logger.getLogger().error("task " + this.id + " err:"+e.Message+",task status"+this.status);
                    TaskStatus to = errNums<10?TaskStatus.Waiting:TaskStatus.Dead;
                    this.onTaskStatusChanged(new TaskStatusChangedEvent(this, this.status, to));
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
            HttpWebResponse res = HttpUtil.getInstance().get(url, 0, SysConfig.DOWNLOAD_UNIT);
            HttpStatusCode status = res.StatusCode;
            res.GetResponseStream().Close();
            res.Close();
            if (status == HttpStatusCode.OK)
            {
                Worker worker = new Worker(this, new DownloadRange(0, size - 1));
                worker.onWorkerStatusChanged += this.OnWorkerStatusChanged;
                this.size = res.ContentLength;
                workers.Add(worker);
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
                    Worker worker = new Worker(this, range);
                    worker.onWorkerStatusChanged += this.OnWorkerStatusChanged;
                    workers.Add(worker);
                    Console.WriteLine(range.from + "," + range.to);
                }
            }
            else
            {
               
                throw new Exception("error http status:" + status);
            }
           
        }

        public bool isDone()
        {
            return this.status == TaskStatus.Finished;
           
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
        public void rebirth()
        {
            init();
        }

        
        #endregion

        #region Task 成员


        public DateTime finishedTime(DateTime finishedTime)
        {
            if (finishedTime != DateTime.MinValue)
                this._finishedTime = finishedTime;
            return _finishedTime;
        }

        #endregion
    }
}
