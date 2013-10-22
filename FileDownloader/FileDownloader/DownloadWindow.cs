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
namespace FileDownloader
{
    public partial class DownloadWindow : Form
    {
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
            task.begin();

             
        }


        public void stringToFile(String fileName, byte[] content)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(content);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
