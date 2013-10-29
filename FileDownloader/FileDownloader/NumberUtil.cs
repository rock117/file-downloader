using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class NumberUtil
    {

        public static string toFixed(float num, int len)
        {
            return toFixed(num + "", len);
        }
        public static string toFixed(double num, int len)
        {
            return toFixed(num + "", len);
        }

        public static string toFixed(long num, int len)
        {
            return toFixed(num + "", len);
        }

        private static string toFixed(string num, int len)
        {
            int index = num.IndexOf('.');
            if (index < 0)
            {
                return num + "." + nString("0", len);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < num.Length; i++)
                {
                    if (i > index + 2)
                    {
                        break;
                    }
                    sb.Append(num.Substring(i, 1));
                }
                return sb.ToString();
            }
        }

        private static string nString(string s, int n)
        {
            if (n <= 0)
                return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }
    }
}
