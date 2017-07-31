using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedControl.time;
using LedControl.basics;

namespace LedControl.segments
{
    public class StaticSegment : LedSegment
    {
        public LedColor color { set; get; }

        public StaticSegment(LedColor color)
        {
            this.color = color;
        }

        protected override void OnUpdate(TimeData timeData)
        {
            foreach (Led led in Leds)
            {
                led.Color = color;
            }
        }
    }
}
