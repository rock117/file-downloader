using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace FileDownloader
{
    public class FileNameCreator
    {

        private static List<string> splitFileName(string fileName)
        {
            int index = fileName.LastIndexOf('.');

            string name;
            string sufix;
            if (index < 0)
            {
                name = fileName;
                sufix = "";
            }
            else
            {
                name = fileName.Substring(0, index);
                sufix = fileName.Substring(index, fileName.Length - index);
            }
            List<string> res = new List<string>();
            res.Add(name);
            res.Add(sufix);
            return res;
        }

        public static List<string> createFileNamesByUrl(string url,string dir, int n)
        {
            List<string> names = new List<string>();
            string fileName = createByUrl(url,dir);
            names.Add(fileName);
            if (n <= 1)
                return names;
            List<string> res = splitFileName(fileName);

            string name = res[0];
            string sufix = res[1];
            
            for (int i = 1; i < n ; i++)
            {
                names.Add(name + "-" + i + sufix);
            }
            return names;
        }
        public static string createByUrl(string url,string dir)
        {
            string name; 
           
            if (url == null)
                throw new Exception("null url");
            if(!Regex.Match(url,"\\.[a-zA-Z]+$").Success)
                 name = System.Guid.NewGuid().ToString();
            try
            {
                int index = url.LastIndexOf('/');
                if (index < 0)
                    name = null;
                int len = url.Length;
                name = url.Substring(index + 1, len - 1 - index);
            }
            catch (Exception e)
            {
                name = System.Guid.NewGuid().ToString();
            }

           bool exist = File.Exists(dir + "/" + name);
           int i = 0;
           List<string> res = splitFileName(name);

           string fname = res[0];
           string sufix = res[1];
           while (exist)
           {
               name = fname + "-" + i + sufix;
               exist = File.Exists(dir + "/" + name);
               i++;
           }
           return name;
        }
    }
}
