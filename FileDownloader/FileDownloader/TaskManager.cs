using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace FileDownloader
{
    [Serializable]
    public class TaskManager
    {
        private List<Task> activeTasks = new List<Task>();
        private List<Task> finishedTasks = new List<Task>();
        
        private static TaskManager taskManager = new TaskManager();
        private Queue<Task> waitTaks = new Queue<Task>();
        static int currId = 1;
        public void pauseTask(string taskId)
        {
            Task task = selectTask(taskId);
            if (task != null && task.getStatus() == TaskStatus.Running)
            {
                task.setStatus(TaskStatus.Pending);
              
            }
        }
        public void removeTask(string taskId)
        {
            
            foreach (Task t in activeTasks)
            {
                if (t.getId() == taskId)
                {
                    t.setStatus(TaskStatus.Dead);
                    activeTasks.Remove(t);
                    break;
                }
            }
            manageTasks();
        }
        public void startTask(string taskId)
        {
            Task task = selectTask(taskId);
            if (task != null && task.getStatus() == TaskStatus.Pending)
            {
                task.setStatus(TaskStatus.Runnable);
            }
        }
        public Task selectTask(string taskId)
        {
            Task task = null;
            foreach (Task t in activeTasks)
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
            task.id = currId+"";
            currId++;
            if (activeTasks.Count < SysConfig.MAX_ACTIVE_TASK)
                activeTasks.Add(task);
            else
                waitTaks.Enqueue(task);
            return task;
        }
        public static TaskManager getInstance()
        {

            return taskManager;
        }
        public List<Task> getActiveTasks()
        {
            return this.activeTasks;
        }
        public void scheduleTask()
        {
            while (true)
            {
                foreach (Task task in activeTasks)
                {
                    TaskStatus status = task.getStatus();
                    if (status == TaskStatus.BeBorn || status == TaskStatus.Runnable)
                    {                         
                            new Thread(new ThreadStart(task.start)).Start();
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public static void freezeTasks(TaskManager manager)
        {
            Serialize(manager);
        }

        private void manageTasks() 
        {
            while (waitTaks.Count > 0 && activeTasks.Count < SysConfig.MAX_ACTIVE_TASK)
            {
                activeTasks.Add(waitTaks.Dequeue());
            }
        }

        public void fireTaskDone(Task task)
        {
            finishedTasks.Add(task);
            //activeTasks.Remove(task);
            //manageTasks();
        }



        public static void Serialize(TaskManager manager)
        {
           
            try
            {
                FileStream fs = new FileStream(SysConfig.BASE_DIR + "/" + SysConfig.META_FILE, FileMode.Create);
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
                FileStream fs = new FileStream(SysConfig.BASE_DIR + "/" + SysConfig.META_FILE, FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                TaskManager manager = (TaskManager)f.Deserialize(fs);
                fs.Close();
                return manager;
            }
            catch (Exception e)
            {
                return null;
            }
           
        }
    }
}
