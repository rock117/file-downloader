using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
     public class HttpRequestHeaders
    {
         public List<Entry> headers()
         {
             List<Entry> list = new List<Entry>();
             return list;
         }
         public Entry header(string headerName)
         {
             return null;
         }
    }


    public class Entry
    {
        public string key{get;set;}
        public string value{get;set;}

    }
}
