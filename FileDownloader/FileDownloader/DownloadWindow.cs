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
using System.Diagnostics;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace FileDownloader
{

    enum ShowMode
    {

        All,
        Finished,
        Running
    }

    public partial class DownloadWindow : Form
    {

        private List<Task> taskList = new List<Task>();
        private TaskManager taskManager = TaskManagerFactory.getInstance().getManager();
        private const long _1K = 1024;
        private const long _1M = _1K * 1024;

        private const int _1MINUTE = 60;
        private const int _1HOUR = 60 * 60;
        private const int taskNum = 11;
        private BackgroundWorker backgroundWorker;
        private string speedTxt = "";
        private delegate void InvokeCallback(string msg);
        private ShowMode showMode = ShowMode.All;


        private const int ID = 0;
        private const int NAME = 1;
        private const int PERCENT = 2;
        private const int SPEED = 3;
        private const int LEFT_TIME = 4;
        private const int FINISHED_TIME = 4;
        private bool exit = false;
        private int rowIndexSelected = 0;





        public DownloadWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.taskGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.taskGrid.ContextMenuStrip = contextMenuStrip1;
            this.initGrid();

            taskManager.ready();
            new Thread(new ThreadStart(taskManager.scheduleTask)).Start();
            new Thread(new ThreadStart(scanTask)).Start();
        }
        void m_comm_MessageEvent(string msg)
        {
            if (this.speedLabel.InvokeRequired)
            {

            }
            else
            {
                this.speedLabel.Text = msg;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private bool isExit()
        {
            return exit;
        }
        private void setSpeedText(object sender, DoWorkEventArgs e)
        {
            this.speedLabel.Text = this.speedTxt;
        }
        protected void initGrid()
        {
            
            this.taskGrid.ColumnCount = 7;
            this.taskGrid.Columns[0].Visible = false;
            this.taskGrid.Columns[1].Name = "文件名";
            this.taskGrid.Columns[2].Name = "下载进度";
            this.taskGrid.Columns[3].Name = "下载速度";
            this.taskGrid.Columns[4].Name = "剩余时间";
            this.taskGrid.Columns[5].Name = "完成时间";
            this.taskGrid.Columns[6].Name = "下载地址";
            this.taskGrid.Columns[6].Visible = false;
           List<DownloadTaskEntry> tasks =  taskManager.getAllTasks();
           this.addRows(tasks);
        }
        
        private void showFinishedTasks()
        {
            List<DownloadTaskEntry> taskList = taskManager.getFinishedTasks();
            this.showTasks(taskList);
        }
        private void showAllTasks()
        {            
            List<DownloadTaskEntry> taskList = taskManager.getAllTasks();
            this.showTasks(taskList);
        }

        private void showTasks(List<DownloadTaskEntry> taskList)
        {
            try
            {
                int rowCount = this.taskGrid.RowCount;
                for (int i = 0; i < rowCount; i++)
                {
                    var id = this.taskGrid.Rows[i].Cells[0].Value.ToString();
                    if (GlobalUtil.contains(taskList, id))
                        this.taskGrid.Rows[i].Visible = true;
                    else
                        this.taskGrid.Rows[i].Visible = false;
                }
            }
            catch (Exception e)
            {

            }
          

        }

        private void showRunningTasks()
        {
            List<DownloadTaskEntry> taskList = taskManager.getRunningTasks();
            this.showTasks(taskList);

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
          this.taskGrid.Rows.Add(new string[] { entry.id, entry.fileName, entry.percent, entry.speed, entry.leftTime,GlobalUtil.formatTime(entry.finishedTime),entry.url });     
        }
        private void newButton_Click(object sender, EventArgs e)
        {
          //  string url = "http://img7.9158.com/200708/23/23/32/2007082308159.jpg";
          // // url = "http://downloads.atlassian.com/software/sourcetree/windows/SourceTreeSetup_1.3.1.exe";
          //  url = "http://common-lisp.net/project/lispbox/test_builds/lispbox-0.7-ccl-1.6-linuxx86.tar.gz";
          ////  url = "http://cdn.market.hiapk.com/data/upload/2013/09_27/15/com.argtgames.xiuxianjie_153434.apk";
          //  this.addTask(url);
            //var s = (100+0.0) / 3;
            //MessageBox.Show("hello "+s);
            NewDownloadForm f = new NewDownloadForm();
            f.ShowDialog();
            string url = f.url;
            string dir = f.dir;
            int n = f.downloadNum;
            if (url == null || url == "")
                return;
            this.addTask(url,dir,n);
        }
        private void addTask(string url, string dir, int n)
        {
            List<string> fileNames = FileNameCreator.createFileNamesByUrl(url, dir, n);
            for (int i = 0; i < n; i++)
            {
                string fileName = fileNames[i];
                Task task = this.taskManager.createTask(url,dir, fileName);
                this.addRow(convert((DownloadTask)task));
                taskList.Add(task);
            }
        }

       

        private void scanTask()
        {
            while (!exit)
            {
                List<DownloadTaskEntry> taskList = taskManager.getAllTasks();
                double speed = 0.0;
                int finishTotal = 0;
                foreach (DownloadTaskEntry taskEntry in taskList)
                {
                    speed += taskEntry.speedL;
                    updateGrid(taskEntry);
                    if (taskEntry.isDone)
                        finishTotal++;
                }

                string speedStr = NumberUtil.toFixed(speed, 1) + " k/s";
                if (speed >= _1K)
                {
                    speedStr = NumberUtil.toFixed(speed / _1K, 2) + " M/s";
                }
                this.speedTxt = "下载速度 " + speedStr;
                this.speedLabel.Text = this.speedTxt;
                this.doneTaskBtn.Text = "已完成(" + finishTotal + ")";
                switch (this.showMode)
                {
                    case ShowMode.All:
                        this.showAllTasks();
                        break;
                    case ShowMode.Finished:
                        this.showFinishedTasks();
                        break;
                    case ShowMode.Running:
                        this.showRunningTasks();
                        break;
                    default:
                        break;

                }

               
                Thread.Sleep(1000);

            }
        }

        private void updateGrid(DownloadTaskEntry taskEntry) 
        {
            string taskId = taskEntry.id;
            int rowCount = this.taskGrid.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string id = this.taskGrid.Rows[i].Cells[0].Value.ToString();
                    if (id == taskId)
                    {
                        var speed = taskEntry.speed;
                        var leftTime = taskEntry.leftTime;
                        if (taskEntry.isDone)
                        {
                            speed = "";
                            leftTime = "";
                        }
                        //this.taskGrid.Rows[i].Cells[1].Value = taskEntry.fileName;
                        this.taskGrid.Rows[i].Cells[2].Value = taskEntry.percent;
                        this.taskGrid.Rows[i].Cells[3].Value = speed;
                        this.taskGrid.Rows[i].Cells[4].Value = leftTime;
                        this.taskGrid.Rows[i].Cells[5].Value = GlobalUtil.formatTime(taskEntry.finishedTime);
                        break;
                    }
                }
                catch (Exception e)
                {
                }
            }
        }

        private DownloadTaskEntry convert(Task _task)
        {
            DownloadTask task = (DownloadTask)_task;
            DownloadTaskEntry res = new DownloadTaskEntry();
            res.fileName =task.fileName;
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
                percent = NumberUtil.toFixed(((curr + 0.0) / size)*100, 1);
                percent = percent == "100.0" ? "100" : percent;
                percent = percent + "%";
               
                var deltaRate = (curr - lastPos+0.0)/_1K;
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
            return res;
        }
        private void startDemonTask()
        {
            new Thread(new ThreadStart(this.scanTask)).Start();
             
        }
        private void taskGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            //List<DataGridViewRow> rows = this.taskGrid.SelectedRows.cou;
            //错误	9	无法将类型“System.Windows.Forms.DataGridViewSelectedRowCollection”隐式转换为“System.Collections.Generic.List<System.Windows.Forms.DataGridViewRow>”	E:\program_data\git-hub-project\file-downloader\FileDownloader\FileDownloader\DownloadWindow.cs	202
            try{ 
                int rowNum = this.taskGrid.SelectedRows.Count;
                for (int i = 0; i < rowNum; i++ )
                {
                   string id = this.taskGrid.SelectedRows[i].Cells[0].Value.ToString();
                   taskManager.pauseTask(id);
                }
            }
            catch(Exception exc){
                
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int rowNum = this.taskGrid.SelectedRows.Count;
            for (int i = 0; i < rowNum; i++)
            {
                try
                {
                    string id = this.taskGrid.SelectedRows[i].Cells[0].Value.ToString();
                    taskManager.startTask(id);
                }
                catch (Exception ee)
                {

                }
           
               
            }
        }

        private void exploreButton_Click(object sender, EventArgs e)
        {
             
            int rowNum = this.taskGrid.SelectedRows.Count;
            if (rowNum <= 0)
            {
                return;
            }
           
            try
            {
                string id = this.taskGrid.SelectedRows[0].Cells[0].Value.ToString();
                Task task = taskManager.selectTask(id);
                DownloadTask dtask = (DownloadTask)task;
                string dir = Regex.Replace(dtask.dir, "/+", "\\");
                Process.Start("explorer", dir);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int rowNum = this.taskGrid.SelectedRows.Count;
                List<DataGridViewRow> list = new List<DataGridViewRow>();
                for (int i = 0; i < rowNum; i++)
                {
                    string id = this.taskGrid.SelectedRows[i].Cells[0].Value.ToString();
                    taskManager.removeTask(id);
                    list.Add(this.taskGrid.SelectedRows[i]);
                }

                foreach (DataGridViewRow row in list)
                {
                    this.taskGrid.Rows.Remove(row);
                }
            }
            catch (Exception except)
            {

            }

           

        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
        
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }

        private void DownloadWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.exit = true;
            TaskManager.freezeTasks(taskManager);           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int rowNum = this.taskGrid.SelectedRows.Count;
            if (rowNum <= 0)
            {
                return;
            }

            try
            {
                string id = this.taskGrid.SelectedRows[0].Cells[0].Value.ToString();
                Task task = taskManager.selectTask(id);
                DownloadTask dtask = (DownloadTask)task;
                string dir = Regex.Replace(dtask.dir, "/+", "\\");
                Process.Start("explorer", dir);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void taskGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    this.taskGrid.ContextMenuStrip.Show(e.X,e.Y);
                    this.rowIndexSelected = e.RowIndex;
                    //弹出操作菜单
                    //contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void 复制urlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                string url = this.taskGrid.Rows[this.rowIndexSelected].Cells[6].Value.ToString();
                Clipboard.SetDataObject(url);
            }
            catch (Exception exc)
            {
            }
        }

        private void taskGrid_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void taskGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           //this.taskGrid.Rows[e.RowIndex];

        }

        private void doneTaskBtn_Click(object sender, EventArgs e)
        {
            this.showMode = ShowMode.Finished;
            this.showFinishedTasks();
        }

        private void downloadingBtn_Click(object sender, EventArgs e)
        {
            this.showMode = ShowMode.Running;
            this.showRunningTasks();
        }

        private void allTaskBtn_Click(object sender, EventArgs e)
        {
            this.showMode = ShowMode.All;
            this.showAllTasks();
        }

    }
}
