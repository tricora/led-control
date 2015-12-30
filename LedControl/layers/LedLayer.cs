using LedControl.basics;
using LedControl.time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.layers
{
    public class LedLayer : Updatable
    {
        internal protected Led[] Leds { get; protected set; }

        protected List<LedSegment> segments = new List<LedSegment>();

        internal LedLayer(Led[] leds)
        {
            Leds = leds;
        }
        
        public void Add(LedSegment seg)
        {
            Add(seg, 0, Leds.Length - 1);
        }

        public void Add(LedSegment seg, int start, int end)
        {
            if (seg == null)
            {
                throw new NullReferenceException();
            }

            if (segments.Contains(seg))
            {
                throw new Exception("LedSegment is already bound to this LedController");
            }

            bool reverse = (end - start < 0);

            if (reverse)
            {
                int tmp = end;
                end = start;
                start = tmp;
            }

            List<Led> ls = new List<Led>();
            for (int i = start; i <= end; i++)
            {
                ls.Add(Leds[i]);
            }

            if (reverse)
            {
                ls.Reverse();
            }
            seg.Leds = ls.ToArray();

            segments.Add(seg);
        }

        public void Remove(LedSegment seg)
        {
            segments.Remove(seg);
        }

        protected override void OnUpdate(TimeData timeData)
        {
            foreach (LedSegment ls in segments)
            {
                ls.Update(timeData);
            }
        }
    }
}
