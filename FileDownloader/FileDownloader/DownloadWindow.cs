using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
namespace FileDownloader
{
    public partial class DownloadWindow : Form
    {

        private List<Task> taskList = new List<Task>();
        

        public DownloadWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //# HttpUtil.head("http://yuehui.163.com/");
           //HttpWebResponse res = HttpUtil.get("http://yuehui.163.com/", 0, null);
           //Stream stream =  res.GetResponseStream();
           //MemoryStream mem = new MemoryStream();
           //byte[] buf = new byte[1024];
           //int len;
           //while ((len = stream.Read(buf, 0, 100)) > 0)
           //{
           //    mem.Write(buf, 0, len);
           //}
           //stringToFile("d:/tmp22.html", mem.ToArray());
           //res.Close();
          //  HttpUtil.download("http://cdn.market.hiapk.com/data/upload/2013/09_27/15/com.argtgames.xiuxianjie_153434.apk");
           // HttpUtil.download("http://img7.9158.com/200708/23/23/32/2007082308159.jpg");
            Task task = new DownloadTask("http://img7.9158.com/200708/23/23/32/2007082308159.jpg", "D:/temp/kkk.jpg");
           // task.begin();

             
        }


        protected void initGrid()
        {
            this.taskGrid.ColumnCount = 4;
            this.taskGrid.Columns[0].Visible = false;
            this.taskGrid.Columns[1].Name = "Name";
            this.taskGrid.Columns[2].Name = "Percent";
            this.taskGrid.Columns[3].Name = "left time";
          
        }
        /// <summary>
        /// add grid rows
        /// </summary>
        /// <param name="dataList"></param>
        private void addRows(List<DownloadTaskEntry> dataList)
        {
            foreach (DownloadTaskEntry entry in dataList)
            {
                this.addRow(entry);
            }
        }
        private void addRow(DownloadTaskEntry entry)
        {
          this.taskGrid.Rows.Add(new string[] { entry.id, entry.fileName, entry.percent, entry.leftTime });     
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            string url = "http://img7.9158.com/200708/23/23/32/2007082308159.jpg";           
            this.addTask(url);
        }
        private void addTask(string url)
        {
            string fileName = FileNameCreator.createByUrl(url);
           
            Task task = TaskManager.getInstance().createTask(url, fileName);
            this.addRow(convert((DownloadTask)task));
            taskList.Add(task);
           
        }

       

        private void scanTask()
        {
            //while (true)
            //{
            //    List<DownloadTaskEntry> taskList = new List<DownloadTaskEntry>();
            //    while (taskList.Count>0)
            //    {
                    
            //        DownloadTaskEntry task = convert((DownloadTask)t);
            //        string percent = task.percent;
            //        string id = task.id;
            //      //  string leftTime = task;
                   
            //    }
            //    updateGrid(taskList);
            //    Thread.Sleep(1000);
                 
            //}
        }

        private void updateGrid(List<DownloadTaskEntry>taskList) { 
             
        }

        private DownloadTaskEntry convert(DownloadTask task)
        {
            DownloadTaskEntry res = new DownloadTaskEntry();
            res.fileName = "abc";
            res.id = "1";
            res.isDone = false;
            res.leftTime = "--";
            res.percent = "0";
            return res;
        }
        private void startDemonTask()
        {
            new Thread(new ThreadStart(this.scanTask)).Start();
        }
        private void taskGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
