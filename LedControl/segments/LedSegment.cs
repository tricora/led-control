using LedControl.basics;
using LedControl.time;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl
{
    abstract public class LedSegment : Updatable
    {
        internal protected Led[] Leds { get; set; }
    }


    public class SimpleLedSegment : LedSegment
    {
        private byte value = 0;
        private Color color = Color.OFF;

        public SimpleLedSegment() {
            //too allow inheritade classes to start with empty constructor
        }

        public SimpleLedSegment(byte offset)
        {
            value = offset;
        }

        protected override void OnUpdate(TimeData timeData)
        {
            UpdateColor(value);
            if (value == 255)
            {
                value = 0;
            } else
            {
                value++;
            }
            foreach (Led led in Leds)
            {
                led.Color = color;
            }
        }

        private void UpdateColor(byte val)
        {
            if (val < 85)
            {
                color = new Color(val * 3, 255 - val * 3, 0);
            } else if (val < 170)
            {
                val -= 85;
                color = new Color(255 - val * 3, 0, val * 3);
            } else
            {
                val -= 170;
                color = new Color(0, val * 3, 255 - val * 3);
            }
        }
    }
}
