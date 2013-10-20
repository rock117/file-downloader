using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class DownloadRange
    {
        public long from { get; set; }
        public long to { get; set; }
        public DownloadRange() { }
        public DownloadRange(long from, long to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
