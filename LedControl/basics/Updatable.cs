using LedControl.time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.basics
{
    public abstract class Updatable
    {
        private long nextUpdateTime = 0;


        /// <summary>
        /// minimum time in miliseconds between to updates get executed
        /// </summary>
        public long Delay { get; set; } = 0;
        
        

        public void Update(TimeData timeData)
        {
            if (timeData.TotalTime < nextUpdateTime)
            {
                return;
            }
            nextUpdateTime = timeData.TotalTime + Delay;
            OnUpdate(timeData);
        }

        abstract protected void OnUpdate(TimeData timeData);
    }
}
