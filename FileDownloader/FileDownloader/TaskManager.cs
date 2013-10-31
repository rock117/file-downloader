using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace FileDownloader
{
    public class TaskManager
    {
        private List<Task> activeTasks = new List<Task>();
        private List<Task> finishedTasks = new List<Task>();
        private static TaskManager taskManager = new TaskManager();
        public Task createTask(DownloadTaskEntry entry)
        {
            Task task = new DownloadTask(entry.url, entry.fileName);
            activeTasks.Add(task);           
            return task;
        }
        public static TaskManager getInstance()
        {

            return taskManager;
        }
        public void scheduleTask()
        {
            while (true)
            {
                foreach (Task task in activeTasks)
                {
                    if(!task.isDone() && task.isPause())
                        new Thread(new ThreadStart(task.start)).Start();
                }
                Thread.Sleep(1000);
            }
        }

    }
}
