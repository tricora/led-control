using LedControl.basics;
using LedControl.time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.segments
{
    public class FlickerSegment : LedSegment
    {
        private bool isOn = true;

        protected override void OnUpdate(TimeData timeData)
        {
            Color c = isOn ? Color.RED : Color.OFF;
            isOn = !isOn;
            foreach (Led led in Leds)
            {
                led.Color = c;
            }
        }
    }
}
