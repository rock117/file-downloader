using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDownloader
{
    public class GlobalUtil
    {
        private const long _1K = 1024;
        private const long _1M = _1K * 1024;

        private const int _1MINUTE = 60;
        private const int _1HOUR = 60 * 60;

        public static bool contains(List<DownloadTaskEntry> list, string id)
        {
            if (list == null)
                return false;
            foreach (DownloadTaskEntry e in list)
            {
                if (e.id == id)
                    return true;
            }
            return false;
        }

        public static string formatTime(DateTime time)
        {

            if (time == DateTime.MinValue)
                return "";
            return time.ToString("yyyy-MM-dd HH:mm");
        }


        public static DownloadTaskEntry convert(Task _task)
        {
            DownloadTask task = (DownloadTask)_task;
            DownloadTaskEntry res = new DownloadTaskEntry();
            res.fileName = task.fileName;
            res.url = task.url;
            res.id = task.id;
            res.isDone = task.isDone();
            res.leftTime = "--";
            string percent = "0%";
            string rate = "0k/s";
            string leftTime = "";
            if (task.getSize() == -1 || task.getSize() == 0)
            {
                percent = "0%";
            }
            else
            {
                long curr = task.getCurrent();
                long size = task.getSize();
                long lastPos = task.getLastPos();
                percent = NumberUtil.toFixed(((curr + 0.0) / size) * 100, 1);
                percent = percent == "100.0" ? "100" : percent;
                percent = percent + "%";

                var deltaRate = (curr - lastPos + 0.0) / _1K;
                res.speedL = deltaRate;
                rate = NumberUtil.toFixed(deltaRate, 1) + " k/s";
                if (deltaRate >= _1K)
                {
                    rate = NumberUtil.toFixed(deltaRate / _1K, 2) + " M/s";
                }

                long leftSize = size - curr;

                if (curr == lastPos)
                {
                    leftTime = "";
                }
                else
                {

                    var time = (leftSize) / (curr - lastPos);// seconds
                    leftTime = HourTimeConverter.convert(time);
                }
            }
            res.speed = rate;
            if (task.isDone())
                percent = "100%";
            res.percent = percent;
            res.leftTime = leftTime;
            res.finishedTime = task.finishedTime(DateTime.MinValue);
            return res;
        }
    }
}
