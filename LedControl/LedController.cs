using LedControl.basics;
using LedControl.device;
using LedControl.events;
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
        private LedEvent ledEvent = null;

        private List<LedSegment> segments = new List<LedSegment>();

        public LedLayerManager LedLayerManager { get; private set; }
        private TimeManager timeManager = new TimeManager();

        public LedDeviceManager LedDeviceManager { get; private set; } = new LedDeviceManager();

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

        

        public void Update()
        {
            if (!timeManager.IsRunning)
            {
                timeManager.Start();
            }
            TimeData td = timeManager.getTimeData();
            LedLayerManager.Update(td);

            if (ledEvent != null)
            {
                if (ledEvent.IsDone)
                {
                    ledEvent = null;
                } else
                {
                    ledEvent.Update(td);
                }
            }

            Show(LedLayerManager.Leds);
        }

       

        public void Show(Led[] leds)
        {
            LedColor[] colors = new LedColor[leds.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = leds[i].Color;
            }
            if (ledEvent != null && !ledEvent.IsDone)
            {
                for (int i = ledEvent.StartIndex; i <= Math.Min(colors.Length-1, ledEvent.EndIndex); i++)
                {
                    colors[i] = ledEvent.Leds[i - ledEvent.StartIndex].Color;
                }
            }
            foreach (ILedDevice dev in LedDeviceManager)
            {
                if (dev.IsOpen)
                {
                    dev.Show(colors);
                }
            }
        }

        public void TurnOff()
        {
            Thread.Sleep(50);
            foreach (ILedDevice dev in LedDeviceManager)
            {
                dev.Show(new LedColor[150]);
            }
        }

        public void SetLedEvent(LedEvent ledevent) {
            ledEvent = ledevent;
        }
    }
}
