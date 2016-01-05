namespace LedApp.device
{
    partial class DeviceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.devicesListView = new System.Windows.Forms.ListView();
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIsOpen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddFormDevice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // devicesListView
            // 
            this.devicesListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.devicesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderIsOpen});
            this.devicesListView.FullRowSelect = true;
            this.devicesListView.GridLines = true;
            this.devicesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.devicesListView.Location = new System.Drawing.Point(3, 3);
            this.devicesListView.Name = "devicesListView";
            this.devicesListView.Size = new System.Drawing.Size(563, 162);
            this.devicesListView.TabIndex = 1;
            this.devicesListView.UseCompatibleStateImageBehavior = false;
            this.devicesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Device";
            this.columnHeaderType.Width = 183;
            // 
            // columnHeaderIsOpen
            // 
            this.columnHeaderIsOpen.Text = "is open";
            this.columnHeaderIsOpen.Width = 68;
            // 
            // buttonAddFormDevice
            // 
            this.buttonAddFormDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFormDevice.Location = new System.Drawing.Point(3, 172);
            this.buttonAddFormDevice.Name = "buttonAddFormDevice";
            this.buttonAddFormDevice.Size = new System.Drawing.Size(103, 32);
            this.buttonAddFormDevice.TabIndex = 2;
            this.buttonAddFormDevice.Text = "Add FormDevice";
            this.buttonAddFormDevice.UseVisualStyleBackColor = true;
            this.buttonAddFormDevice.Click += new System.EventHandler(this.buttonAddFormDevice_Click);
            // 
            // DeviceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddFormDevice);
            this.Controls.Add(this.devicesListView);
            this.Name = "DeviceControl";
            this.Size = new System.Drawing.Size(569, 212);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView devicesListView;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderIsOpen;
        private System.Windows.Forms.Button buttonAddFormDevice;
    }
}
