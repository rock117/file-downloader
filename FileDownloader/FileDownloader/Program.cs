using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
namespace FileDownloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
      //  [STAThread]
        static void Main()
        {
            //Console.WriteLine("abc");
            //string url = "http://img7.9158.com/200708/23/23/32/2007082308159.jpg";
            //string fileName = FileNameCreator.createByUrl(url);
            //Task task = new DownloadTask(url, fileName);
            //task.start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DownloadWindow());
            
           // Console.Read();
        }
    }
}
