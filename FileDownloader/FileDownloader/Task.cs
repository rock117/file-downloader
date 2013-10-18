using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    interface Task
    {
        bool isDone();
        void begin();
        string percent();
    }
}
