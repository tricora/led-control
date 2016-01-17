using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.audio
{
    public class AudioDevice
    {
        public MMDevice Device { get; internal protected set; }
    }
}
