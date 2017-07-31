using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedControl.basics;

namespace LedControl.blendmodes
{
    public class AverageBlendMode : IBlendMode
    {
        public LedColor Blend(LedColor[] colors)
        {
            int red = 0, green = 0, blue = 0;
            for(int i = 0; i < colors.Length; i++)
            {
                red += colors[i].R;
                green += colors[i].G;
                blue += colors[i].B;
            }
            return new LedColor((byte)Math.Round((float)red / colors.Length), (byte)Math.Round((float)green / colors.Length), (byte)Math.Round((float)blue / colors.Length));
        }
    }
}
