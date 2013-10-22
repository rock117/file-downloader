using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class DownloadTaskEntry
    {
        public string url { get; set; }
        public string fileName { get; set; }
        public bool isDone { get; set; }
    }
}
