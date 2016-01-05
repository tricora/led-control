using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedControl.time;
using LedControl.basics;

namespace LedControl.segments
{
    public class MultiRiderSegment : LedSegment
    {
        private float pos = 0;
        private Color color = Color.WHITE;
        private int range = 5;
        private float offset = 0.5f;

        public MultiRiderSegment(Color c, int range, float offset)
        {
            color = c;
            this.range = range;
            this.offset = offset;
        }

        protected override void OnUpdate(TimeData timeData)
        {
            pos += offset;

            if (pos >= range)
            {
                pos = 0;
            }
            if (pos < 0)
            {
                pos = (float)range + offset;
            }
            

            for (int i = 0; i < Leds.Count(); i++)
            {
                float local = (i + pos) % range;
                float s = local / range;
                //s = Math.Abs(1 - s);

                Leds[i].Color = new Color((byte)(s * color.R), (byte)(s * color.G), (byte)(s * color.B));
            }
        }
    }
}
