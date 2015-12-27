using LedControl;
using LedControl.device;
using LedControl.layers;
using LedControl.segments;
using LedHttpServer;
using NAudio.CoreAudioApi;
using System;
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
        private LedController ledController;

        private HttpServer server;

        public FormMain()
        {
            InitializeComponent();

            ledController = new LedController(50);
            SerialDevice serialDevice = new SerialDevice("COM3", 50);
            serialDevice.ColorCorrection = new ColorCorrection(1, 0.3F, 1);
            //ledController.AddDevice(new ConsoleDevice(50, 3));
            //ledController.AddDevice(new FormDevice(3, 1));

            //ledController.AddDevice(serialDevice);

            MMDeviceEnumerator devices = new MMDeviceEnumerator();

            MMDevice device = devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            LedLayer layer = ledController.LedLayerManager.CreateAndAddLayer();

            LedSegment leftAudio = new AudioSegment(device, AudioMode.LEFT);
            leftAudio.Delay = 0;
            layer.Add(leftAudio, 0, 24);
            layer.Add(new AudioSegment(device, AudioMode.RIGHT), 49, 25);
            //layer.Add(new FlickerSegment(), 24, 25);

            //LedLayer layer2 = ledController.LedLayerManager.CreateAndAddLayer();
            //layer2.Add(new NightRiderSegment(LedControl.basics.Color.BLUE), 0, 49);

            ledController.OpenAllDevices();


            server = new HttpServer(Properties.Settings.Default.server_port);

            if (Properties.Settings.Default.server_running)
            {
                StartServer();
            } else
            {
                StopServer();
            }


            timerLedUpdate.Start();
        }

       

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            timerLedUpdate.Stop();
            ledController.TurnOff();
            ledController.CloseAllDevices();

            Properties.Settings.Default["server_running"] = server.IsRunning;
            Properties.Settings.Default.Save();

            server.Stop();
        }

        private void timerLedUpdate_Tick(object sender, EventArgs e)
        {
            ledController.Update();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
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
        }

        private void StartServer()
        {
            server.Start();
            buttonStartStopServer.Text = "Stop Server";
        }
    }
}
