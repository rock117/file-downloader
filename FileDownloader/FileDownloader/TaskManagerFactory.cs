using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class TaskManagerFactory
    {
        private static TaskManagerFactory factory = new TaskManagerFactory();
        private TaskManager manager;
        private TaskManagerFactory()
        {
            manager = TaskManager.Dserialize();
            if (manager == null)
                manager = TaskManager.getInstance();
            
        }
        public static TaskManagerFactory getInstance()
        {
            return factory;
        }
        
 
    }
}
