using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public enum TaskStatus
    {
        BeBorn,
        Running, 
        Runnable, //not running, just able to run
        Pending,//dead, but not finished
        Dead,//not finish, but dead
        Finished 
    }
}
