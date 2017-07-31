using LedControl.basics;
using LedControl.time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.segments
{
    public class BinaryWatchSegment : LedSegment
    {
        protected override void OnUpdate(TimeData timeData)
        {
            int s = DateTime.Now.TimeOfDay.Seconds;
            if (s < 20)
            {
                Leds[0].Color = new LedColor(0, 0, s*10);
            } else if (s < 40)
            {
                s -= 19;
                Leds[0].Color = new LedColor(0, s * 10, 0);
            } else
            {
                s -= 39;
                Leds[0].Color = new LedColor(s * 10, 0, 0);
            }
            
        }
    }
}
