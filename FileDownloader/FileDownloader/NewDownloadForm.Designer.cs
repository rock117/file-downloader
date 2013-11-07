namespace FileDownloader
{
    partial class NewDownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadLabel = new System.Windows.Forms.Label();
            this.downloadDirLabel = new System.Windows.Forms.Label();
            this.downloadUrlTextBox = new System.Windows.Forms.TextBox();
            this.downloadDirTextBox = new System.Windows.Forms.TextBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.downloadNumtextBox = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(26, 22);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(53, 12);
            this.downloadLabel.TabIndex = 0;
            this.downloadLabel.Text = "下载地址";
            // 
            // downloadDirLabel
            // 
            this.downloadDirLabel.AutoSize = true;
            this.downloadDirLabel.Location = new System.Drawing.Point(26, 61);
            this.downloadDirLabel.Name = "downloadDirLabel";
            this.downloadDirLabel.Size = new System.Drawing.Size(53, 12);
            this.downloadDirLabel.TabIndex = 1;
            this.downloadDirLabel.Text = "下载目录";
            // 
            // downloadUrlTextBox
            // 
            this.downloadUrlTextBox.Location = new System.Drawing.Point(96, 22);
            this.downloadUrlTextBox.Name = "downloadUrlTextBox";
            this.downloadUrlTextBox.Size = new System.Drawing.Size(372, 21);
            this.downloadUrlTextBox.TabIndex = 2;
            // 
            // downloadDirTextBox
            // 
            this.downloadDirTextBox.Location = new System.Drawing.Point(96, 61);
            this.downloadDirTextBox.Name = "downloadDirTextBox";
            this.downloadDirTextBox.Size = new System.Drawing.Size(198, 21);
            this.downloadDirTextBox.TabIndex = 3;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(219, 131);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "确定";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "下载数";
            // 
            // downloadNumtextBox
            // 
            this.downloadNumtextBox.Location = new System.Drawing.Point(96, 97);
            this.downloadNumtextBox.Name = "downloadNumtextBox";
            this.downloadNumtextBox.Size = new System.Drawing.Size(100, 21);
            this.downloadNumtextBox.TabIndex = 6;
            this.downloadNumtextBox.Text = "1";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(300, 61);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(34, 23);
            this.browseBtn.TabIndex = 7;
            this.browseBtn.Text = "...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // NewDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 181);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.downloadNumtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.downloadDirTextBox);
            this.Controls.Add(this.downloadUrlTextBox);
            this.Controls.Add(this.downloadDirLabel);
            this.Controls.Add(this.downloadLabel);
            this.Name = "NewDownloadForm";
            this.Text = "新建下载任务";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewDownloadForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewDownloadForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Label downloadDirLabel;
        private System.Windows.Forms.TextBox downloadUrlTextBox;
        private System.Windows.Forms.TextBox downloadDirTextBox;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox downloadNumtextBox;
        private System.Windows.Forms.Button browseBtn;
    }
}