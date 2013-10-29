using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class SysConfig
    {
        public const int _1K = 1024;
        public const int DOWNLOAD_UNIT = _1K;
        public const string DOWNLOAD_DIR = "d:/temp/mydownload/";
        public const int WORKERS_NUM = 17;
    }
}
