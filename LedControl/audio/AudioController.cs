using NAudio.CoreAudioApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using System.Windows.Forms;
using System.Threading;

namespace LedControl.audio
{
    public class AudioController : IMMNotificationClient
    {
        public AudioDevice DefaultDevice { get; private set; } = new AudioDevice();

        private MMDeviceEnumerator enumerator = new MMDeviceEnumerator();

        private Control synchronizeContext;

        public AudioController(Control control)
        {
            UpdateDefaultDevice();
            synchronizeContext = control;
            //enumerator.RegisterEndpointNotificationCallback(this);
        }

        public void UpdateDefaultDevice()
        {
            DefaultDevice.Device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }

        public delegate void defaultDeviceDelegate();
        public void OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId)
        {
            if (flow != DataFlow.Render || role != Role.Multimedia)
            {
                return;
            }
            synchronizeContext.BeginInvoke(new defaultDeviceDelegate(UpdateDefaultDevice));
            //UpdateDefaultDevice();
        }

        public void OnDeviceAdded(string pwstrDeviceId)
        {
            //Console.WriteLine("added");
        }

        public void OnDeviceRemoved(string deviceId)
        {
            //Console.WriteLine("removed");
        }

        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            //Console.WriteLine("state changed: " + deviceId + "  - " + newState);
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
            //Console.WriteLine("value changed: " + key.propertyId);
        }
    }
}
