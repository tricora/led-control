namespace LedApp
{
    partial class FormMain
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
            this.timerLedUpdate = new System.Windows.Forms.Timer(this.components);
            this.systemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTryContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFormDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStartStopServer = new System.Windows.Forms.Button();
            this.deviceControl1 = new LedApp.device.DeviceControl();
            this.updateDefaultAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTryContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerLedUpdate
            // 
            this.timerLedUpdate.Interval = 30;
            this.timerLedUpdate.Tick += new System.EventHandler(this.timerLedUpdate_Tick);
            // 
            // systemTray
            // 
            this.systemTray.ContextMenuStrip = this.sysTryContextMenuStrip;
            this.systemTray.Text = "LED Control";
            this.systemTray.Visible = true;
            this.systemTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.systemTray_MouseDoubleClick);
            // 
            // sysTryContextMenuStrip
            // 
            this.sysTryContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateDefaultAudioToolStripMenuItem,
            this.addFormDeviceToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.sysTryContextMenuStrip.Name = "sysTryContextMenuStrip";
            this.sysTryContextMenuStrip.Size = new System.Drawing.Size(202, 98);
            // 
            // addFormDeviceToolStripMenuItem
            // 
            this.addFormDeviceToolStripMenuItem.Name = "addFormDeviceToolStripMenuItem";
            this.addFormDeviceToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addFormDeviceToolStripMenuItem.Text = "Create UI Display Device";
            this.addFormDeviceToolStripMenuItem.Click += new System.EventHandler(this.addFormDeviceToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonStartStopServer
            // 
            this.buttonStartStopServer.Location = new System.Drawing.Point(507, 341);
            this.buttonStartStopServer.Name = "buttonStartStopServer";
            this.buttonStartStopServer.Size = new System.Drawing.Size(128, 32);
            this.buttonStartStopServer.TabIndex = 2;
            this.buttonStartStopServer.Text = "Start Server";
            this.buttonStartStopServer.UseVisualStyleBackColor = true;
            this.buttonStartStopServer.Click += new System.EventHandler(this.buttonStartStopServer_Click);
            // 
            // deviceControl1
            // 
            this.deviceControl1.Location = new System.Drawing.Point(12, 12);
            this.deviceControl1.Name = "deviceControl1";
            this.deviceControl1.Size = new System.Drawing.Size(623, 212);
            this.deviceControl1.TabIndex = 3;
            // 
            // updateDefaultAudioToolStripMenuItem
            // 
            this.updateDefaultAudioToolStripMenuItem.Name = "updateDefaultAudioToolStripMenuItem";
            this.updateDefaultAudioToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.updateDefaultAudioToolStripMenuItem.Text = "Update Default Audio";
            this.updateDefaultAudioToolStripMenuItem.Click += new System.EventHandler(this.updateDefaultAudioToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 385);
            this.Controls.Add(this.deviceControl1);
            this.Controls.Add(this.buttonStartStopServer);
            this.Name = "FormMain";
            this.Text = "Led Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.sysTryContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerLedUpdate;
        private System.Windows.Forms.NotifyIcon systemTray;
        private System.Windows.Forms.Button buttonStartStopServer;
        private System.Windows.Forms.ContextMenuStrip sysTryContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFormDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private device.DeviceControl deviceControl1;
        private System.Windows.Forms.ToolStripMenuItem updateDefaultAudioToolStripMenuItem;
    }
}

