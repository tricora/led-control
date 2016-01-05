using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LedControl.device;

namespace LedApp.device
{
    public partial class DeviceControl : UserControl
    {
        private LedDeviceManager ledDeviceManager;

        public DeviceControl()
        {
            
            InitializeComponent();
        }

        public void SetLedDeviceManager(LedDeviceManager ldm)
        {
            ledDeviceManager = ldm;
            UpdateDeviceListView();
        }

        public void AddDevice(ILedDevice ledDevice)
        {
            ledDeviceManager.Add(ledDevice);
            UpdateDeviceListView();
        }

        public void RemoveDevice(ILedDevice ledDevice)
        {
            ledDeviceManager.Remove(ledDevice);
            UpdateDeviceListView();
        }

        private void UpdateDeviceListView()
        {
            devicesListView.Items.Clear();
            foreach (ILedDevice dev in ledDeviceManager)
            {
                devicesListView.Items.Add(new ListViewItem(new string[] { dev.GetType().Name.ToString(), dev.IsOpen.ToString() }));
            }

        }

        public void CreateFormDevice()
        {
            FormDevice dev = new FormDevice(3, 1);
            dev.Open();
            ledDeviceManager.Add(dev);

            dev.FormClosing += FormDevice_Closing;

            UpdateDeviceListView();
        }

        public void FormDevice_Closing(object sender, FormClosingEventArgs e)
        {
            FormDevice d = (FormDevice)sender;
            RemoveDevice(d);
            d.FormClosing -= FormDevice_Closing;
        }

        private void buttonAddFormDevice_Click(object sender, EventArgs e)
        {
            CreateFormDevice();
        }
    }
}
