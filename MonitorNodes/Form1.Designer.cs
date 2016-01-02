namespace MonitorNodes
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ipAddressBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monitorButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.waitTime = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.autoScroll = new System.Windows.Forms.CheckBox();
            this.attemptOSVersion = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsWithGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceIPv4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reliabilityLabel = new System.Windows.Forms.Label();
            this.reliabilityCounter = new System.Windows.Forms.Label();
            this.succeedLabel = new System.Windows.Forms.Label();
            this.succeedCounter = new System.Windows.Forms.Label();
            this.failLabel = new System.Windows.Forms.Label();
            this.failCounter = new System.Windows.Forms.Label();
            this.pingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.showFailsOnly = new System.Windows.Forms.CheckBox();
            this.maxTimeOutLabel = new System.Windows.Forms.Label();
            this.maxTimeOutCounter = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.myIPAddress = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oslabelTitle = new System.Windows.Forms.Label();
            this.osLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // ipAddressBox
            // 
            this.ipAddressBox.Location = new System.Drawing.Point(13, 49);
            this.ipAddressBox.Name = "ipAddressBox";
            this.ipAddressBox.Size = new System.Drawing.Size(118, 20);
            this.ipAddressBox.TabIndex = 0;
            this.ipAddressBox.TextChanged += new System.EventHandler(this.ipAddressBox_TextChanged);
            this.ipAddressBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipAddressBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address or hostname:";
            // 
            // monitorButton
            // 
            this.monitorButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.monitorButton.Location = new System.Drawing.Point(141, 30);
            this.monitorButton.Name = "monitorButton";
            this.monitorButton.Size = new System.Drawing.Size(73, 48);
            this.monitorButton.TabIndex = 2;
            this.monitorButton.Text = "Monitor";
            this.monitorButton.UseVisualStyleBackColor = true;
            this.monitorButton.Click += new System.EventHandler(this.monitorButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Location = new System.Drawing.Point(220, 30);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(73, 48);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // waitTime
            // 
            this.waitTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.waitTime.FormattingEnabled = true;
            this.waitTime.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.waitTime.Location = new System.Drawing.Point(544, 57);
            this.waitTime.Name = "waitTime";
            this.waitTime.Size = new System.Drawing.Size(60, 21);
            this.waitTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sleep time (seconds):";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(299, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "Write To File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // autoScroll
            // 
            this.autoScroll.AutoSize = true;
            this.autoScroll.Checked = true;
            this.autoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScroll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.autoScroll.Location = new System.Drawing.Point(16, 400);
            this.autoScroll.Name = "autoScroll";
            this.autoScroll.Size = new System.Drawing.Size(83, 18);
            this.autoScroll.TabIndex = 8;
            this.autoScroll.Text = "Auto Scroll";
            this.autoScroll.UseVisualStyleBackColor = true;
            // 
            // attemptOSVersion
            // 
            this.attemptOSVersion.AutoSize = true;
            this.attemptOSVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.attemptOSVersion.Location = new System.Drawing.Point(109, 400);
            this.attemptOSVersion.Name = "attemptOSVersion";
            this.attemptOSVersion.Size = new System.Drawing.Size(124, 18);
            this.attemptOSVersion.TabIndex = 9;
            this.attemptOSVersion.Text = "Attempt OS Version";
            this.attemptOSVersion.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(378, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 48);
            this.button2.TabIndex = 10;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.saveAsWithGraphToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveAsWithGraphToolStripMenuItem
            // 
            this.saveAsWithGraphToolStripMenuItem.Name = "saveAsWithGraphToolStripMenuItem";
            this.saveAsWithGraphToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveAsWithGraphToolStripMenuItem.Text = "Save As With Graph";
            this.saveAsWithGraphToolStripMenuItem.Click += new System.EventHandler(this.saveAsWithGraphToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stayOnTopToolStripMenuItem,
            this.chartTypeToolStripMenuItem,
            this.forceIPv4ToolStripMenuItem,
            this.hideGraphToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // stayOnTopToolStripMenuItem
            // 
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.stayOnTopToolStripMenuItem.Text = "Stay On Top";
            this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
            // 
            // chartTypeToolStripMenuItem
            // 
            this.chartTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnToolStripMenuItem,
            this.pieToolStripMenuItem});
            this.chartTypeToolStripMenuItem.Name = "chartTypeToolStripMenuItem";
            this.chartTypeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.chartTypeToolStripMenuItem.Text = "Chart Type";
            // 
            // columnToolStripMenuItem
            // 
            this.columnToolStripMenuItem.Name = "columnToolStripMenuItem";
            this.columnToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.columnToolStripMenuItem.Text = "Column";
            this.columnToolStripMenuItem.Click += new System.EventHandler(this.columnToolStripMenuItem_Click);
            // 
            // pieToolStripMenuItem
            // 
            this.pieToolStripMenuItem.Name = "pieToolStripMenuItem";
            this.pieToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pieToolStripMenuItem.Text = "Pie";
            this.pieToolStripMenuItem.Click += new System.EventHandler(this.pieToolStripMenuItem_Click);
            // 
            // forceIPv4ToolStripMenuItem
            // 
            this.forceIPv4ToolStripMenuItem.Name = "forceIPv4ToolStripMenuItem";
            this.forceIPv4ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.forceIPv4ToolStripMenuItem.Text = "Force IPv4";
            this.forceIPv4ToolStripMenuItem.Click += new System.EventHandler(this.forceIPv4ToolStripMenuItem_Click);
            // 
            // hideGraphToolStripMenuItem
            // 
            this.hideGraphToolStripMenuItem.Name = "hideGraphToolStripMenuItem";
            this.hideGraphToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.hideGraphToolStripMenuItem.Text = "Hide Graph";
            this.hideGraphToolStripMenuItem.Click += new System.EventHandler(this.hideGraphToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.changeLogToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.viewSourceCodeToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.changeLogToolStripMenuItem.Text = "Changelog";
            this.changeLogToolStripMenuItem.Click += new System.EventHandler(this.changeLogToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // viewSourceCodeToolStripMenuItem
            // 
            this.viewSourceCodeToolStripMenuItem.Name = "viewSourceCodeToolStripMenuItem";
            this.viewSourceCodeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.viewSourceCodeToolStripMenuItem.Text = "View Source Code";
            this.viewSourceCodeToolStripMenuItem.Click += new System.EventHandler(this.viewSourceCodeToolStripMenuItem_Click);
            // 
            // reliabilityLabel
            // 
            this.reliabilityLabel.AutoSize = true;
            this.reliabilityLabel.Location = new System.Drawing.Point(496, 100);
            this.reliabilityLabel.Name = "reliabilityLabel";
            this.reliabilityLabel.Size = new System.Drawing.Size(54, 13);
            this.reliabilityLabel.TabIndex = 12;
            this.reliabilityLabel.Text = "Reliability:";
            // 
            // reliabilityCounter
            // 
            this.reliabilityCounter.AutoSize = true;
            this.reliabilityCounter.Location = new System.Drawing.Point(555, 100);
            this.reliabilityCounter.Name = "reliabilityCounter";
            this.reliabilityCounter.Size = new System.Drawing.Size(13, 13);
            this.reliabilityCounter.TabIndex = 13;
            this.reliabilityCounter.Text = "0";
            // 
            // succeedLabel
            // 
            this.succeedLabel.AutoSize = true;
            this.succeedLabel.Location = new System.Drawing.Point(496, 125);
            this.succeedLabel.Name = "succeedLabel";
            this.succeedLabel.Size = new System.Drawing.Size(53, 13);
            this.succeedLabel.TabIndex = 14;
            this.succeedLabel.Text = "Succeed:";
            // 
            // succeedCounter
            // 
            this.succeedCounter.AutoSize = true;
            this.succeedCounter.Location = new System.Drawing.Point(555, 125);
            this.succeedCounter.Name = "succeedCounter";
            this.succeedCounter.Size = new System.Drawing.Size(13, 13);
            this.succeedCounter.TabIndex = 15;
            this.succeedCounter.Text = "0";
            // 
            // failLabel
            // 
            this.failLabel.AutoSize = true;
            this.failLabel.Location = new System.Drawing.Point(496, 153);
            this.failLabel.Name = "failLabel";
            this.failLabel.Size = new System.Drawing.Size(38, 13);
            this.failLabel.TabIndex = 16;
            this.failLabel.Text = "Failed:";
            // 
            // failCounter
            // 
            this.failCounter.AutoSize = true;
            this.failCounter.Location = new System.Drawing.Point(540, 153);
            this.failCounter.Name = "failCounter";
            this.failCounter.Size = new System.Drawing.Size(13, 13);
            this.failCounter.TabIndex = 17;
            this.failCounter.Text = "0";
            // 
            // pingChart
            // 
            chartArea1.Name = "ChartArea1";
            this.pingChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pingChart.Legends.Add(legend1);
            this.pingChart.Location = new System.Drawing.Point(609, 84);
            this.pingChart.Name = "pingChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Pings";
            this.pingChart.Series.Add(series1);
            this.pingChart.Size = new System.Drawing.Size(358, 336);
            this.pingChart.TabIndex = 18;
            this.pingChart.Text = "Ping Chart";
            // 
            // showFailsOnly
            // 
            this.showFailsOnly.AutoSize = true;
            this.showFailsOnly.Location = new System.Drawing.Point(239, 400);
            this.showFailsOnly.Name = "showFailsOnly";
            this.showFailsOnly.Size = new System.Drawing.Size(101, 17);
            this.showFailsOnly.TabIndex = 19;
            this.showFailsOnly.Text = "Only Show Fails";
            this.showFailsOnly.UseVisualStyleBackColor = true;
            // 
            // maxTimeOutLabel
            // 
            this.maxTimeOutLabel.AutoSize = true;
            this.maxTimeOutLabel.Location = new System.Drawing.Point(497, 180);
            this.maxTimeOutLabel.Name = "maxTimeOutLabel";
            this.maxTimeOutLabel.Size = new System.Drawing.Size(74, 13);
            this.maxTimeOutLabel.TabIndex = 20;
            this.maxTimeOutLabel.Text = "Max Timeout: ";
            // 
            // maxTimeOutCounter
            // 
            this.maxTimeOutCounter.AutoSize = true;
            this.maxTimeOutCounter.Location = new System.Drawing.Point(578, 180);
            this.maxTimeOutCounter.Name = "maxTimeOutCounter";
            this.maxTimeOutCounter.Size = new System.Drawing.Size(13, 13);
            this.maxTimeOutCounter.TabIndex = 21;
            this.maxTimeOutCounter.Text = "0";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(496, 207);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(64, 13);
            this.addressLabel.TabIndex = 22;
            this.addressLabel.Text = "IP Address: ";
            // 
            // myIPAddress
            // 
            this.myIPAddress.AutoSize = true;
            this.myIPAddress.Location = new System.Drawing.Point(496, 232);
            this.myIPAddress.Name = "myIPAddress";
            this.myIPAddress.Size = new System.Drawing.Size(52, 13);
            this.myIPAddress.TabIndex = 23;
            this.myIPAddress.Text = "127.0.0.1";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.IP,
            this.Time,
            this.RTT,
            this.Timeout,
            this.TTL});
            this.dgv1.Location = new System.Drawing.Point(12, 84);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.Size = new System.Drawing.Size(478, 310);
            this.dgv1.TabIndex = 24;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // RTT
            // 
            this.RTT.HeaderText = "RTT";
            this.RTT.Name = "RTT";
            this.RTT.ReadOnly = true;
            // 
            // Timeout
            // 
            this.Timeout.HeaderText = "Timeout";
            this.Timeout.Name = "Timeout";
            this.Timeout.ReadOnly = true;
            // 
            // TTL
            // 
            this.TTL.HeaderText = "TTL";
            this.TTL.Name = "TTL";
            this.TTL.ReadOnly = true;
            // 
            // oslabelTitle
            // 
            this.oslabelTitle.AutoSize = true;
            this.oslabelTitle.Location = new System.Drawing.Point(497, 264);
            this.oslabelTitle.Name = "oslabelTitle";
            this.oslabelTitle.Size = new System.Drawing.Size(28, 13);
            this.oslabelTitle.TabIndex = 25;
            this.oslabelTitle.Text = "OS: ";
            // 
            // osLabel
            // 
            this.osLabel.AutoSize = true;
            this.osLabel.Location = new System.Drawing.Point(527, 264);
            this.osLabel.Name = "osLabel";
            this.osLabel.Size = new System.Drawing.Size(38, 13);
            this.osLabel.TabIndex = 26;
            this.osLabel.Text = "NONE";
            // 
            // Form1
            // 
            this.AcceptButton = this.monitorButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.stopButton;
            this.ClientSize = new System.Drawing.Size(967, 429);
            this.Controls.Add(this.osLabel);
            this.Controls.Add(this.oslabelTitle);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.myIPAddress);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.maxTimeOutCounter);
            this.Controls.Add(this.maxTimeOutLabel);
            this.Controls.Add(this.showFailsOnly);
            this.Controls.Add(this.pingChart);
            this.Controls.Add(this.failCounter);
            this.Controls.Add(this.failLabel);
            this.Controls.Add(this.succeedCounter);
            this.Controls.Add(this.succeedLabel);
            this.Controls.Add(this.reliabilityCounter);
            this.Controls.Add(this.reliabilityLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.attemptOSVersion);
            this.Controls.Add(this.autoScroll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.waitTime);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.monitorButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipAddressBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Monitor Node";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipAddressBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button monitorButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ComboBox waitTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox autoScroll;
        private System.Windows.Forms.CheckBox attemptOSVersion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
        private System.Windows.Forms.Label reliabilityLabel;
        private System.Windows.Forms.Label reliabilityCounter;
        private System.Windows.Forms.Label succeedLabel;
        private System.Windows.Forms.Label succeedCounter;
        private System.Windows.Forms.Label failLabel;
        private System.Windows.Forms.Label failCounter;
        private System.Windows.Forms.DataVisualization.Charting.Chart pingChart;
        private System.Windows.Forms.ToolStripMenuItem chartTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceIPv4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsWithGraphToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem hideGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.CheckBox showFailsOnly;
        private System.Windows.Forms.Label maxTimeOutLabel;
        private System.Windows.Forms.Label maxTimeOutCounter;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label myIPAddress;
        private System.Windows.Forms.ToolStripMenuItem viewSourceCodeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label oslabelTitle;
        private System.Windows.Forms.Label osLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn RTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timeout;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTL;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

