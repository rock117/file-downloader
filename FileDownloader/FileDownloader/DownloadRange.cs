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


        public static List<DownloadRange> splitRange(long from, long to, long n)
        {
            List<DownloadRange> list = new List<DownloadRange>();
            long delta = to - from;
            long per = delta / n;
            long total = 0;
            long f = 0;
            long t;
            for (long i = 0; i < n; i++)
            {
                t = f + per - 1;
                if (i == n - 1)
                    t = to - 1;
                list.Add(new DownloadRange(f, t));
                f = t + 1;
            }

            return list;
        }

    }
}
