using LedControl.basics;
using LedControl.device;
using LedControl.layers;
using LedControl.time;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedControl
{
    public class LedController
    {
        private List<LedSegment> segments = new List<LedSegment>();

        private List<ILedDevice> devices = new List<ILedDevice>(1);

        public LedLayerManager LedLayerManager { get; private set; }
        private TimeManager timeManager = new TimeManager();

        public int DeviceCount {
            get {
                return devices.Count;
            }
        }

        public LedController(int ledCount)
        {
            LedLayerManager = new LedLayerManager();

            Led[] leds = new Led[ledCount];
            for (var i = 0; i < ledCount; i++)
            {
                leds[i] = new Led();
            }

            LedLayerManager.Leds = leds;

        }

        public void AddDevice(ILedDevice dev)
        {
            if (dev == null)
            {
                return;
            }
            if (!devices.Contains(dev))
            {
                devices.Add(dev);
            }
        }

        public void RemoveDevice(ILedDevice dev)
        {
            if (dev == null)
            {
                return;
            }
            devices.Remove(dev);
        }

        public void OpenAllDevices()
        {
            foreach(ILedDevice dev in devices)
            {
                dev.Open();
            }
            timeManager.Start();
        }

        public void Update()
        {
            if (!timeManager.IsRunning)
            {
                timeManager.Start();
            }
            TimeData td = timeManager.getTimeData();
            LedLayerManager.Update(td);
            Show(LedLayerManager.Leds);
        }

        public void CloseAllDevices()
        {
            timeManager.Stop();
            foreach (ILedDevice dev in devices)
            {
                dev.Close();
            }
        }

        public void Show(Led[] leds)
        {
            Color[] colors = new Color[leds.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = leds[i].Color;
            }
            foreach (ILedDevice dev in devices)
            {
                if (dev.IsOpen())
                {
                    dev.Show(colors);
                }
            }
        }

        public void TurnOff()
        {
            Thread.Sleep(50);
            foreach (ILedDevice dev in devices)
            {
                dev.Show(new Color[150]);
            }
        }
    }
}
