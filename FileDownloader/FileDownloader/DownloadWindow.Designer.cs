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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.taskGrid = new System.Windows.Forms.DataGridView();
            this.downloadTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.downloadTaskEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rightPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskEntryBindingSource)).BeginInit();
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
            this.rightPanel.Controls.Add(this.menuPanel);
            this.rightPanel.Controls.Add(this.tablePanel);
            this.rightPanel.Location = new System.Drawing.Point(172, 1);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(607, 423);
            this.rightPanel.TabIndex = 1;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.deleteButton);
            this.menuPanel.Controls.Add(this.newButton);
            this.menuPanel.Controls.Add(this.pauseButton);
            this.menuPanel.Controls.Add(this.startButton);
            this.menuPanel.Location = new System.Drawing.Point(3, 3);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(601, 49);
            this.menuPanel.TabIndex = 1;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(310, 8);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(217, 8);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "new";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(109, 8);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 8);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "start";
            this.startButton.UseVisualStyleBackColor = true;
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
            this.initGrid();
            // 
            // DownloadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 424);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Name = "DownloadWindow";
            this.Text = "Form1";
            this.rightPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taskGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadTaskEntryBindingSource)).EndInit();
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
    }
}

