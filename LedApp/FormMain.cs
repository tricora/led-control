using LedControl;
using LedControl.audio;
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
        private AudioController audioController;

        private HttpServer server;

        private Icon serverOffIcon;
        private Icon serverOnIcon;

        public FormMain()
        {
            InitializeComponent();

            LoadIcons();

            ledController = new LedController(50);
            ILedDevice serialDevice = new SerialDevice("COM3", 50);
            //ILedDevice consoleDevice = new ConsoleDevice(50, 3);
            //ILedDevice formDevice = new FormDevice(3, 1);

            Console.WriteLine(serialDevice.GetHashCode());
            //Console.WriteLine(consoleDevice.GetHashCode());
            //Console.WriteLine(formDevice.GetHashCode());

            float brightness = 1f;
            serialDevice.ColorCorrection = new ColorCorrection(1*brightness, 0.3F*brightness, 1*brightness);
            //ledController.LedDeviceManager.Add(consoleDevice);
            //ledController.LedDeviceManager.Add(formDevice);

            ledController.LedDeviceManager.Add(serialDevice);

            
            audioController = new AudioController(this);
            AudioDevice device = audioController.DefaultDevice;

            LedLayer layer = ledController.LedLayerManager.CreateAndAddLayer();

            layer.Add(new AudioSegment(device, AudioMode.LEFT), 49, 36);
            layer.Add(new AudioSegment(device, AudioMode.RIGHT), 0, 13);
            layer.Add(new AudioSegment(device, AudioMode.LEFT), 25, 35);
            layer.Add(new AudioSegment(device, AudioMode.RIGHT), 24, 14);

            //layer.Add(new SimpleLedSegment(), 14, 35);

            //layer.Add(new AudioSegment(device, AudioMode.MASTER), 0, 49);


            LedLayer layer2 = ledController.LedLayerManager.CreateAndAddLayer();
            //layer2.Add(new NightRiderSegment(LedControl.basics.Color.BLUE));
            layer2.Add(new MultiRiderSegment(new LedControl.basics.Color( 0, 0, 30), 30, -0.3f));

            //LedLayer layer3 = ledController.LedLayerManager.CreateAndAddLayer();
            //layer3.Add(new MultiRiderSegment(new LedControl.basics.Color(30, 0, 0), 30, 0.3f));

            ledController.LedDeviceManager.OpenAll();


            server = new HttpServer(Properties.Settings.Default.server_port, messageQueue);

            if (Properties.Settings.Default.server_running)
            {
                StartServer();
            } else
            {
                StopServer();
            }

            deviceControl1.SetLedDeviceManager(ledController.LedDeviceManager);
            
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
            ledController.LedDeviceManager.CloseAll();

            Properties.Settings.Default["server_running"] = server.IsRunning;
            Properties.Settings.Default.Save();

            server.Stop();

            Application.Exit();
        }

        private void MinimizeToSystemTray()
        {
            Properties.Settings.Default.app_is_visible = false;
            Properties.Settings.Default.Save();
            Hide();
        }

        private void ReturnFormSystemTray()
        {
            Properties.Settings.Default.app_is_visible = true;
            Properties.Settings.Default.Save();
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
            while (messageQueue.TryDequeue(out s)) {
                TimeSpanEvent tse = new TimeSpanEvent(0, 49, 10000);
                MultiRiderSegment mrs = new MultiRiderSegment(LedControl.basics.Color.GREEN, 5, 0.8f);
                tse.Add(mrs);
                ledController.SetLedEvent(tse);
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

        private void systemTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                ReturnFormSystemTray();
            }
        }

        private void addFormDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deviceControl1.CreateFormDevice();
        }
    }
}
