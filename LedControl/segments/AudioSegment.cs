using LedControl.audio;
using LedControl.basics;
using LedControl.time;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.segments
{
    public class AudioSegment : LedSegment
    {
        private AudioMode _mode;
        private AudioDevice audioDevice;

        public AudioSegment(AudioDevice device, AudioMode mode)
        {
            _mode = mode;

            audioDevice = device;
        }
        
        protected override void OnUpdate(TimeData timeData)
        {
            
            float value;

            
                switch (_mode)
                {
                    case AudioMode.LEFT:
                        value = audioDevice.Device.AudioMeterInformation.PeakValues[0];
                        break;
                    case AudioMode.RIGHT:
                        value = audioDevice.Device.AudioMeterInformation.PeakValues[1];
                        break;
                    case AudioMode.MASTER:
                        value = audioDevice.Device.AudioMeterInformation.MasterPeakValue;
                        break;
                    default:
                        value = 0f;
                        break;
                }
                SetLeds((int)Math.Round(value * (Leds.Length - 1)));
            
        }

        private void SetLeds(int val)
        {
            //clear the strip
            for (int i = val + 1; i < Leds.Length; i++)
            {
                Leds[i].Color = LedColor.OFF;
            }

            //make sure we write into Leds range
            if (val >= Leds.Length)
            {
                val = Leds.Length - 1;
            }

            //green base
            //Color c = new Color(0x00, 0x10, 0);
            LedColor c = new LedColor(0x66, 0x00, 0x77);
            for (int i = 0; i < val - 1; i++ )
            {
                Leds[i].Color = c;
            }

            //red max indicator
            Leds[val].Color = new LedColor(0xFF, 0, 0x30);

            //yellow middle
            //c = new Color(0x5F, 0x3F, 0);
            //c = new Color(0xFF, 0xFF, 0);
            c = new LedColor(0xBB, 0, 0x88);
            for (int i = Math.Max(0, val - 3); i < val; i++)
            {
                Leds[i].Color = c;
            }
                
            
            
        }
    }

    public enum AudioMode
    {
        LEFT,
        RIGHT,
        MASTER
    }
}
