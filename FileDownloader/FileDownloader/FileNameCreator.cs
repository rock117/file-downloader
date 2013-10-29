using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class FileNameCreator
    {
        public static string createByUrl(string url)
        {
            if (url == null)
                throw new Exception("null url"); 
            int index = url.LastIndexOf('/');
            if (index < 0)
                return null;
            int len = url.Length;
            return url.Substring(index+1, len-1 - index);
        }
    }
}
