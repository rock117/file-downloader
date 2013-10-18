using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class FileTask: Task
    {
        #region Task Members

        public bool isDone()
        {
            return false;
        }

        public void begin()
        {
            throw new NotImplementedException();
        }

        public string percent()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
