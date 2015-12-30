using LedControl.basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedControl.time;
using LedControl.layers;

namespace LedControl.events
{
    public abstract class LedEvent : LedLayer
    {
        public int StartIndex { get; protected set; }
        public int EndIndex { get; protected set; }
        public bool IsDone { get; protected set; } = false;

        public LedEvent(int startIndex, int endIndex) : base(new Led[Math.Abs(endIndex - startIndex) + 1])
        {
            if (startIndex > EndIndex)
            {
                StartIndex = endIndex;
                EndIndex = startIndex;
            } else
            {
                StartIndex = startIndex;
                EndIndex = endIndex;
            }
            
            for (int i = 0; i < Leds.Length; i++)
            {
                Leds[i] = new Led();
            }
        }

        protected override void OnUpdate(TimeData timeData)
        {
            if (IsDone || CheckForDone(timeData))
            {
                IsDone = true;
                return;
            }
            base.OnUpdate(timeData);
        }

        protected abstract bool CheckForDone(TimeData timeData);
    }
}
