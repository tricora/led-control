using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.device
{
    public struct ColorCorrection
    {
        public float R { get; private set; }
        public float G { get; private set; }
        public float B { get; private set; }

        public ColorCorrection(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
