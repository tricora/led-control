﻿using LedControl;
using LedControl.device;
using LedControl.events;
using LedControl.layers;
using LedControl.segments;
using LedHttpServer;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedApp
{
    public partial class FormMain : Form
    {
        private ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();


        private LedController ledController;

        private HttpServer server;

        private Icon serverOffIcon;
        private Icon serverOnIcon;

        public FormMain()
        {
            InitializeComponent();

            LoadIcons();

            ledController = new LedController(50);
            SerialDevice serialDevice = new SerialDevice("COM3", 50);

            float brightness = 0.5f;
            serialDevice.ColorCorrection = new ColorCorrection(1*brightness, 0.3F*brightness, 1*brightness);
            //ledController.AddDevice(new ConsoleDevice(50, 3));
            //ledController.AddDevice(new FormDevice(3, 1));

            ledController.AddDevice(serialDevice);

            MMDeviceEnumerator devices = new MMDeviceEnumerator();

            MMDevice device = devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            LedLayer layer = ledController.LedLayerManager.CreateAndAddLayer();

            layer.Add(new AudioSegment(device, AudioMode.LEFT), 49, 36);
            layer.Add(new AudioSegment(device, AudioMode.RIGHT), 0, 13);
            layer.Add(new AudioSegment(device, AudioMode.LEFT), 25, 35);
            layer.Add(new AudioSegment(device, AudioMode.RIGHT), 24, 14);
            //layer.Add(new SimpleLedSegment(), 14, 35);

            //layer.Add(new FlickerSegment(), 0, 49);


            LedLayer layer2 = ledController.LedLayerManager.CreateAndAddLayer();
            layer2.Add(new NightRiderSegment(LedControl.basics.Color.BLUE));

            ledController.OpenAllDevices();


            server = new HttpServer(Properties.Settings.Default.server_port, messageQueue);

            if (Properties.Settings.Default.server_running)
            {
                StartServer();
            } else
            {
                StopServer();
            }


            timerLedUpdate.Start();
        }

        private void LoadIcons()
        {
            serverOnIcon = LedApp.Properties.Resources.ServerOn;
            serverOffIcon = LedApp.Properties.Resources.ServerOff;
        }

        public void Shutdown()
        {
            systemTray.Visible = false;

            timerLedUpdate.Stop();
            ledController.TurnOff();
            ledController.CloseAllDevices();

            Properties.Settings.Default["server_running"] = server.IsRunning;
            Properties.Settings.Default.Save();

            server.Stop();

            Application.Exit();
        }

        private void MinimizeToSystemTray()
        {
            Hide();
        }

        private void ReturnFormSystemTray()
        {
            
            Show();
            WindowState = FormWindowState.Normal;
        }
       

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                if (MessageBox.Show("Do you really want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Shutdown();
                }
                e.Cancel = true;
            }
        }

        private void timerLedUpdate_Tick(object sender, EventArgs e)
        {
            string s;
            if (messageQueue.TryDequeue(out s)) {
                TimeSpanEvent tse = new TimeSpanEvent(0, 20, 3000);
                FlickerSegment fs = new FlickerSegment();
                fs.Delay = 500;
                tse.Add(fs);
                ledController.AddLedEvent(tse);
            }
               
            ledController.Update();
        }

        private void buttonStartStopServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (server.IsRunning)
                {
                    StopServer();
                }
                else
                {
                    StartServer();
                }
            }
            catch (Exception) { }
        }

        private void StopServer()
        {
            server.Stop();
            buttonStartStopServer.Text = "Start Server";
            systemTray.Icon = serverOffIcon;
            this.Icon = serverOffIcon;
        }

        private void StartServer()
        {
            server.Start();
            buttonStartStopServer.Text = "Stop Server";
            systemTray.Icon = serverOnIcon;
            this.Icon = serverOnIcon;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shutdown();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                MinimizeToSystemTray();
            }
        }

        private void CreateFormDevice()
        {
            FormDevice dev = new FormDevice(3, 1);
            dev.Open();
            ledController.AddDevice(dev);

            dev.FormClosing += FormDevice_Closing;
        }

        public void FormDevice_Closing(object sender, FormClosingEventArgs e)
        {
            FormDevice d = (FormDevice)sender;
            ledController.RemoveDevice(d);
            d.FormClosing -= FormDevice_Closing;
            Console.WriteLine(ledController.DeviceCount);
        }

        private void buttonAddFormDevice_Click(object sender, EventArgs e)
        {
            CreateFormDevice();
        }

        private void systemTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                ReturnFormSystemTray();
            }
        }

        private void addFormDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormDevice();
        }
    }
}
