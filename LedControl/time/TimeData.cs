using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.time
{
    public class TimeData
    {
        public long TotalTime { get; private set; }
        public long FrameTime { get; private set; }

        public TimeData(long totalTime, long frameTime)
        {
            TotalTime = totalTime;
            FrameTime = frameTime;
        }
    }
}
