using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public interface Task
    {
        void start();
        void stop();
        bool isDone();
        bool isPause();
    }
}
