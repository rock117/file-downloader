using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader.Event
{
    public class TaskStatusChangedEvent
    {
        public Task task;
        public TaskStatus from;
        public TaskStatus to;
        public TaskStatusChangedEvent(Task task, TaskStatus from, TaskStatus to)
        {
            this.from = from;
            this.to = to;
            this.task = task;
        }
    }
}
