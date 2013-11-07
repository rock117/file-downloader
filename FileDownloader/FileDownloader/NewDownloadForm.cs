using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace FileDownloader
{
    public partial class NewDownloadForm : Form
    {
        public string url { get; set; }
        public string dir { get; set; }
        public int downloadNum { get; set; }
        public NewDownloadForm()
        {
            this.url = null;
            this.dir = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.downloadNum = 1;
            InitializeComponent();
            this.downloadDirTextBox.Text = this.dir;
        }

        

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.url = this.downloadUrlTextBox.Text.Trim();
            this.dir = this.downloadDirTextBox.Text.Trim();
            if (!Directory.Exists(this.dir))
            {
                MessageBox.Show(this.dir + "不存在，请重写选择一个目录");
                return;
            }
            this.Close();           
        }


        private void NewDownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            

            try
            {
                this.downloadNum = Int32.Parse(this.downloadNumtextBox.Text.Trim());
            }
            catch (Exception ee)
            {
                this.downloadNum = 1;
            }
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            this.downloadDirTextBox.Text = dlg.SelectedPath;
        }

        private void NewDownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        
    }
}
