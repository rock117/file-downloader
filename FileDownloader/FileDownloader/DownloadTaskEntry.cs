using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class DownloadTaskEntry
    {
        public string id { get; set; }
        public string url { get; set; }
        public string fileName { get; set; }
        public bool isDone { get; set; }
        public string percent { get; set; }
        public string leftTime { get; set; }
        public string speed { get; set; }
        public double speedL { get; set; }
       
    }
}
