namespace FileDownloader
{
    partial class DownloadWindow
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.downloadTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.downloadTaskEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // downloadTaskBindingSource
            // 
            this.downloadTaskBindingSource.DataSource = typeof(FileDownloader.DownloadTask);
            // 
            // downloadTaskEntryBindingSource
            // 
            this.downloadTaskEntryBindingSource.DataSource = typeof(FileDownloader.DownloadTaskEntry);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(277, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.ColumnCount = 3;
            this.dataGridView1.Columns[0].Name = "col0";
            this.dataGridView1.Columns[1].Name = "col1";
            this.dataGridView1.Columns[2].Name = "col21";
            this.dataGridView1.Rows.Add(new string[] {"a","b","c" });
            this.dataGridView1.Rows.Add(new string[] { "1", "2", "3" });
            // 
            // DownloadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 304);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "DownloadWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource downloadTaskBindingSource;
        private System.Windows.Forms.BindingSource downloadTaskEntryBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

