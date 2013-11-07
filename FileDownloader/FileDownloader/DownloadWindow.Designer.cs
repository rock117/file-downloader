﻿namespace FileDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadWindow));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.selectBtn = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.exploreLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.taskGrid = new System.Windows.Forms.DataGridView();
            this.downloadTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.downloadTaskEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制urlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskEntryBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftPanel.Location = new System.Drawing.Point(-3, 1);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(169, 423);
            this.leftPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.selectBtn);
            this.rightPanel.Controls.Add(this.speedLabel);
            this.rightPanel.Controls.Add(this.textBox1);
            this.rightPanel.Controls.Add(this.downloadLabel);
            this.rightPanel.Controls.Add(this.menuPanel);
            this.rightPanel.Controls.Add(this.tablePanel);
            this.rightPanel.Location = new System.Drawing.Point(172, 1);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(696, 470);
            this.rightPanel.TabIndex = 1;
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(268, 433);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(36, 23);
            this.selectBtn.TabIndex = 4;
            this.selectBtn.Text = "...";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(497, 436);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.speedLabel.Size = new System.Drawing.Size(53, 12);
            this.speedLabel.TabIndex = 3;
            this.speedLabel.Text = "下载速度";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 433);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 21);
            this.textBox1.TabIndex = 2;
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(5, 436);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(53, 12);
            this.downloadLabel.TabIndex = 0;
            this.downloadLabel.Text = "下载目录";
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.exploreLabel);
            this.menuPanel.Controls.Add(this.deleteButton);
            this.menuPanel.Controls.Add(this.newButton);
            this.menuPanel.Controls.Add(this.pauseButton);
            this.menuPanel.Controls.Add(this.startButton);
            this.menuPanel.Location = new System.Drawing.Point(3, 3);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(601, 49);
            this.menuPanel.TabIndex = 1;
            // 
            // exploreLabel
            // 
            this.exploreLabel.Image = ((System.Drawing.Image)(resources.GetObject("exploreLabel.Image")));
            this.exploreLabel.Location = new System.Drawing.Point(404, 8);
            this.exploreLabel.Name = "exploreLabel";
            this.exploreLabel.Size = new System.Drawing.Size(27, 23);
            this.exploreLabel.TabIndex = 5;
            this.exploreLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(310, 8);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "删除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(217, 8);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "新建";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(109, 8);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "暂停";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 8);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "开始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tablePanel
            // 
            this.tablePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tablePanel.Controls.Add(this.taskGrid);
            this.tablePanel.Location = new System.Drawing.Point(3, 58);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(601, 362);
            this.tablePanel.TabIndex = 0;
            // 
            // taskGrid
            // 
            this.taskGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskGrid.Location = new System.Drawing.Point(3, 3);
            this.taskGrid.Name = "taskGrid";
            this.taskGrid.RowTemplate.Height = 23;
            this.taskGrid.Size = new System.Drawing.Size(597, 354);
            this.taskGrid.TabIndex = 0;
            this.taskGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskGrid_CellContentClick);
            this.taskGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.taskGrid_CellMouseClick);
            this.taskGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.taskGrid_CellMouseDown);
            this.taskGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.taskGrid_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制urlToolStripMenuItem,
            this.删除任务ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 70);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // 复制urlToolStripMenuItem
            // 
            this.复制urlToolStripMenuItem.Name = "复制urlToolStripMenuItem";
            this.复制urlToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.复制urlToolStripMenuItem.Text = "复制网址到剪贴板";
            this.复制urlToolStripMenuItem.Click += new System.EventHandler(this.复制urlToolStripMenuItem_Click);
            // 
            // 删除任务ToolStripMenuItem
            // 
            this.删除任务ToolStripMenuItem.Name = "删除任务ToolStripMenuItem";
            this.删除任务ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.删除任务ToolStripMenuItem.Text = "删除任务";
            // 
            // DownloadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 473);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Name = "DownloadWindow";
            this.Text = "闪电貂";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DownloadWindow_FormClosed);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taskGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskEntryBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource downloadTaskBindingSource;
        private System.Windows.Forms.BindingSource downloadTaskEntryBindingSource;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel tablePanel;
        private System.Windows.Forms.DataGridView taskGrid;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Label exploreLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制urlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除任务ToolStripMenuItem;
    }
}

