using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class HourTimeConverter
    {
        public static string convert(long t)
        {
            const int _1hour = 60 * 60;
            const int _1min = 60;
            long h = t / _1hour;
            long hmod = t % _1hour;
            if (hmod == 0)
                return h + " 小时";
            long min = hmod / _1min;
            long mmod = hmod % _1min;
            return h + " 小时" + min +" 分"+mmod+" 秒";
        }
    }
}
