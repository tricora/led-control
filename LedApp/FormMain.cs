using LedControl;
using LedControl.device;
using LedControl.layers;
using LedControl.segments;
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
        public FormMain()
        {
            InitializeComponent();

            ledController = new LedController(50);
            SerialDevice serialDevice = new SerialDevice("COM3", 50);
            serialDevice.ColorCorrection = new ColorCorrection(1, 0.3F, 1);
            ledController.AddDevice(new ConsoleDevice(50, 1));

            ledController.AddDevice(serialDevice);

            MMDeviceEnumerator devices = new MMDeviceEnumerator();

            MMDevice device = devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            LedLayer layer = ledController.LedLayerManager.CreateAndAddLayer();

            LedSegment leftAudio = new AudioSegment(device, AudioMode.LEFT);
            leftAudio.Delay = 0;
            layer.Add(leftAudio, 0, 24);
            layer.Add(new AudioSegment(device, AudioMode.RIGHT), 49, 25);
            //layer.Add(new FlickerSegment(), 24, 25);

            ledController.OpenAllDevices();

            timerLedUpdate.Start();
        }

        private LedController ledController;

       

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            timerLedUpdate.Stop();
            ledController.TurnOff();
            ledController.CloseAllDevices();
        }

        private void timerLedUpdate_Tick(object sender, EventArgs e)
        {
            ledController.Update();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}
