using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
   
    public interface Task
    {
        long getCurrent();
        string getId();
        void start();
        void stop();
        bool isDone();
        TaskStatus getStatus();
        void setStatus(TaskStatus status);
    }
}
