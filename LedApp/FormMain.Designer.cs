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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonAddFormDevice = new System.Windows.Forms.Button();
            this.buttonStartStopServer = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addFormDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.addFormDeviceToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.sysTryContextMenuStrip.Name = "sysTryContextMenuStrip";
            this.sysTryContextMenuStrip.Size = new System.Drawing.Size(202, 76);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(510, 216);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // buttonAddFormDevice
            // 
            this.buttonAddFormDevice.Location = new System.Drawing.Point(12, 234);
            this.buttonAddFormDevice.Name = "buttonAddFormDevice";
            this.buttonAddFormDevice.Size = new System.Drawing.Size(103, 32);
            this.buttonAddFormDevice.TabIndex = 1;
            this.buttonAddFormDevice.Text = "Add FormDevice";
            this.buttonAddFormDevice.UseVisualStyleBackColor = true;
            this.buttonAddFormDevice.Click += new System.EventHandler(this.buttonAddFormDevice_Click);
            // 
            // buttonStartStopServer
            // 
            this.buttonStartStopServer.Location = new System.Drawing.Point(394, 234);
            this.buttonStartStopServer.Name = "buttonStartStopServer";
            this.buttonStartStopServer.Size = new System.Drawing.Size(128, 32);
            this.buttonStartStopServer.TabIndex = 2;
            this.buttonStartStopServer.Text = "Start Server";
            this.buttonStartStopServer.UseVisualStyleBackColor = true;
            this.buttonStartStopServer.Click += new System.EventHandler(this.buttonStartStopServer_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(121, 234);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // addFormDeviceToolStripMenuItem
            // 
            this.addFormDeviceToolStripMenuItem.Name = "addFormDeviceToolStripMenuItem";
            this.addFormDeviceToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addFormDeviceToolStripMenuItem.Text = "Create UI Display Device";
            this.addFormDeviceToolStripMenuItem.Click += new System.EventHandler(this.addFormDeviceToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 275);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonStartStopServer);
            this.Controls.Add(this.buttonAddFormDevice);
            this.Controls.Add(this.listView1);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonAddFormDevice;
        private System.Windows.Forms.Button buttonStartStopServer;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip sysTryContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFormDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

