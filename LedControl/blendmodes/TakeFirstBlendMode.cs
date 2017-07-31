using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedControl.basics;

namespace LedControl.blendmodes
{
    class TakeFirstBlendMode : IBlendMode
    {
        public LedColor Blend(LedColor[] colors)
        {
            return colors[0];
        }
    }
}
