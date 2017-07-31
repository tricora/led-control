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
            LedColor c = isOn ? LedColor.RED : LedColor.GREEN;
            isOn = !isOn;
            foreach (Led led in Leds)
            {
                led.Color = c;
            }
        }
    }
}
