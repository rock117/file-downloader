using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class GlobalConfig
    {
        private static string rootDir = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/file-downloader";
        private static object lockObj = new object();
        public static string getRootDir()
        {
            lock (lockObj)
            {
                return rootDir;
            }
        }
        public static void setRootDir(string rDir)
        {
            lock (lockObj)
            {
                rootDir = rDir;
            }
        }
        
    }
}
