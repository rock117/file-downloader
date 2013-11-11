using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public enum TaskStatus
    {
        Waiting,
        Running, 
        Pending,//dead, but not finished
        Sicked,//not finish, but dead
        Dead,//
        Finished 
    }
}
