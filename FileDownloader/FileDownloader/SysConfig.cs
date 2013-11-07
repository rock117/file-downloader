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
        public const int WORKERS_NUM = 5;
        public const int MAX_ACTIVE_TASK = 150;
        public const string BASE_DIR = "d:/temp/mydownload";
        public const string META_FILE = "tasks.meta";
    }
}
