using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader.Event
{
    public class WorkerStatusChangedEvent
    {
        public Worker worker;
        public WorkerStatus from;
        public WorkerStatus to;

        public WorkerStatusChangedEvent(Worker worker, WorkerStatus from, WorkerStatus to)
        {
            this.worker = worker;
            this.from = from;
            this.to = to;
        }
    }
}
