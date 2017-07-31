using LedControl.basics;
using LedControl.time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.segments
{
    public class NightRiderSegment : LedSegment
    {
        private int pos = 0;
        private int direction = 1;
        private int skipper = 0;
        private LedColor color;

        public NightRiderSegment(LedColor c)
        {
            color = c;
        }

        public NightRiderSegment()
        {
            color = LedColor.RED;
        }

        protected override void OnUpdate(TimeData timeData)
        {
            skipper++;
            if (skipper >= 10)
            {
                skipper = 0;
                Leds[pos].Color = LedColor.OFF;
                pos += direction;
                Leds[pos].Color = color;
                if (pos == 0 || pos == Leds.Length - 1)
                {
                    direction *= -1;
                }
            }
        }
    }
}
