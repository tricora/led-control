using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedControl.time;

namespace LedControl.events
{
    public class TimeSpanEvent : LedEvent
    {
        private long time = 0;
        private long ttl;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="ttl">time to live in mili seconds</param>
        public TimeSpanEvent(int startIndex, int endIndex, long ttl) : base(startIndex, endIndex)
        {
            this.ttl = ttl;
        }

        protected override bool CheckForDone(TimeData timeData)
        {
            time += timeData.FrameTime;
            if (time >= ttl)
            {
                return true;
            }
            return false;
        }


    }
}
