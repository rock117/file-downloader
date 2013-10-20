using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileDownloader
{
    public class FileUtil
    {
        public static void writeToFile(string fileName, byte[] data)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        public static void streamToFile(string fileName, Stream stream)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            byte []buf = new byte[1024];
            int len;
            while((len = stream.Read(buf, 0, 1024))>0){
                fs.Write(buf, 0, len);
            }
            fs.Close();
        }
    }
}
