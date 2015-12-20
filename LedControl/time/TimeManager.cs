using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.time
{
    class TimeManager : Stopwatch
    {
        private long lastFrameTime;
        public TimeData getTimeData()
        {
            long current = this.ElapsedMilliseconds;
            TimeData res = new TimeData(current, current - lastFrameTime);
            lastFrameTime = current;
            return res;
        }
    }
}
