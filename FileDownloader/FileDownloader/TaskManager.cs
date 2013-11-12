using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FileDownloader.Event;
namespace FileDownloader
{
    [Serializable]
    public class TaskManager
    {
      //  private List<Task> activeTasks = new List<Task>();
        private List<Task> pendingTasks = new List<Task>();
        private List<Task> runningTasks = new List<Task>();
        private List<Task> finishedTasks = new List<Task>();
        private List<Task> waittingTasks = new List<Task>();
        private List<Task> deathTasks = new List<Task>();
        private List<Task> allTasks = new List<Task>();
        private bool _ready = false;
        private Dictionary<TaskStatus, List<Task>> tasksDict = new Dictionary<TaskStatus, List<Task>>();


      //  private static TaskManager taskManager = new TaskManager();
         
        static int currId = 1;
        private object lockObj = new object();

        public TaskManager()
        {
            tasksDict.Add(TaskStatus.Running, runningTasks);
            tasksDict.Add(TaskStatus.Pending, pendingTasks);
            tasksDict.Add(TaskStatus.Finished, finishedTasks);
            tasksDict.Add(TaskStatus.Waiting, waittingTasks);
            tasksDict.Add(TaskStatus.Dead, deathTasks);
        }


        public void OnTaskStatusChanged(TaskStatusChangedEvent e)
        {
            lock (lockObj)
            {
                Task task = e.task;
                List<Task> deleteTasks = tasksDict[e.from];
                List<Task> addedTasks = tasksDict[e.to];
                task.setStatus(e.to);
                removeItem(deleteTasks, task);
                addedTasks.Add(task);
                if (e.to == TaskStatus.Finished)
                {
                    task.finishedTime(DateTime.Now);
                }
            }
        }
        private bool removeItem(List<Task> tasks, string taskId)
        {
            foreach (Task task in tasks)
            {
                if (taskId == task.getId())
                {
                    tasks.Remove(task);
                    return true;
                }
            }
            return false;
        }
        private bool removeItem(List<Task> tasks, Task task)
        {
            string taskId = task==null?null:task.getId();
            return removeItem(tasks, taskId);
        }

        public void pauseTask(string taskId)
        {
            Task task = selectTask(taskId);
            if (task == null)
                return;
            lock(lockObj){
                if (task.getStatus() == TaskStatus.Running)
                {
                    task.setStatus(TaskStatus.Pending);
                    removeItem(runningTasks, task);
                    pendingTasks.Add(task);
                }
            
            }
        }
        public void removeTask(string taskId)
        {
      
            lock (lockObj)
            {
                Task task = selectTask(taskId);
                
                if (task == null)
                {
                    return;
                }
               bool b1 = false;
               bool b2 = false, b3 = false, b4 = false, b5 = false;
               if(!b1)
                    b2 = removeItem(pendingTasks, taskId);
               if(!b2)
                    b3 = removeItem(runningTasks, taskId);
               if(!b3)
                    b4 = removeItem(finishedTasks, taskId);
               if(!b4)
                    b5 = removeItem(waittingTasks, taskId);
               if (!b5)
                   removeItem(deathTasks, taskId);
               removeItem(allTasks, taskId);
               task.setStatus(TaskStatus.Dead);
            }
             
        }
        public void startTask(string taskId)
        {
            Task task = selectTask(taskId);
            if (task == null)
                return;
           
            lock (lockObj)
            {
                TaskStatus st = task.getStatus();
                if (st == TaskStatus.Pending)
                {

                    task.setStatus(TaskStatus.Waiting);
                    removeItem(pendingTasks, task);
                    waittingTasks.Add(task);
                }
                else if (st == TaskStatus.Dead)
                {
                    task.rebirth();
                    task.setStatus(TaskStatus.Waiting);
                    removeItem(deathTasks, task);
                    waittingTasks.Add(task);
                }
            }

        }
        public Task selectTask(string taskId)
        {
            Task task = null;
            foreach (Task t in allTasks)
            {
                if (t.getId() == taskId)
                {
                    task = t;
                    break;
                }
            }
            return task;

        }
        
        public Task createTask(string url, string dir, string fileName)
        {
            DownloadTask task = new DownloadTask(url, dir, fileName);
            task.setStatus(TaskStatus.Waiting);
            task.onTaskStatusChanged += this.OnTaskStatusChanged;
            task.id = currId+"";
            currId++;
            lock(lockObj){
                waittingTasks.Add(task);
                allTasks.Add(task);
            }
            return task;
        }
        
        public List<Task> getActiveTasks()
        {
            return this.allTasks;
        }
        public void scheduleTask()
        {
            while (_ready)
            {
                lock (lockObj)
                {
                    while(waittingTasks.Count > 0 && runningTasks.Count <= SysConfig.MAX_ACTIVE_TASK)
                    {
                        Task task = waittingTasks[0];
                        waittingTasks.Remove(task);

                        runningTasks.Add(task);
                        task.setStatus(TaskStatus.Running);
                        new Thread(new ThreadStart(task.start)).Start();
                    }

                }
                Thread.Sleep(1000);
            }
        }

        public static void freezeTasks(TaskManager manager)
        {
            manager.stopAll();
            Serialize(manager);
        }

        private void stopAll()
        {
            lock (lockObj)
            {
                this._ready = false;
                foreach (Task task in allTasks)
                {
                    if (task.getStatus() == TaskStatus.Running)
                    {
                        task.setStatus(TaskStatus.Waiting);
                        removeItem(runningTasks, task);
                        waittingTasks.Add(task);
                    }
                }//for each
            }//lock end
        }

        public void ready()
        {
            this._ready = true;
        }

        public static void Serialize(TaskManager manager)
        {

            try
            {
                string dir = GlobalConfig.getRootDir() + "/";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                FileStream fs = new FileStream(dir+ SysConfig.META_FILE, FileMode.Create);
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(fs, manager);
                fs.Close();
            }
            catch (Exception e)
            {
            }
        }
        public static TaskManager Dserialize()
        {
            try
            {
                FileStream fs = new FileStream(GlobalConfig.getRootDir() + "/" + SysConfig.META_FILE, FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                TaskManager manager = (TaskManager)f.Deserialize(fs);
                fs.Close();
                return manager;
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public List<DownloadTaskEntry> getAllTasks()
        {
            lock (lockObj)
            {
                List<DownloadTaskEntry> result = new List<DownloadTaskEntry>();
                foreach (Task task in allTasks)
                {
                    result.Add(GlobalUtil.convert(task));
                }
                 return result;
            }
           
        }
        public List<DownloadTaskEntry> getRunningTasks()
        {
            lock (lockObj)
            {
                List<DownloadTaskEntry> result = new List<DownloadTaskEntry>();
                foreach (Task task in allTasks)
                {
                    if(task.getStatus() != TaskStatus.Finished)
                        result.Add(GlobalUtil.convert(task));
                }
                 return result;
            }
        }
        public List<DownloadTaskEntry> getFinishedTasks()
        {
            lock (lockObj)
            {
                List<DownloadTaskEntry> result = new List<DownloadTaskEntry>();
                foreach (Task task in finishedTasks)
                {
                    result.Add(GlobalUtil.convert(task));
                }
                 return result;
            }
        }
    }
}
