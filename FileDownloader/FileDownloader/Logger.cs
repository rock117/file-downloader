using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using System.IO;
namespace FileDownloader
{
    public class Logger
    {
        private ILog log = LogManager.GetLogger("FileDownloader");
        private static Logger logger = new Logger();
        private Logger()
        {         
            XmlConfigurator.Configure(new FileInfo(@"E:\program_data\git-hub-project\file-downloader\FileDownloader\FileDownloader\config\log4net.xml"));           
        }

        public static Logger getLogger(){
            return logger;
        }

        public void debug(string msg)
        {
            log.Debug(msg);
        }
        public void info(string msg)
        {
            log.Info(msg);
        }
        public void error(string msg)
        {
            log.Error(msg);
        }
    }
}
