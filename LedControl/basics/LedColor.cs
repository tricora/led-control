using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.basics
{
    public struct LedColor
    {
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        public LedColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public LedColor(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
        }

        public LedColor(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}]", R.ToString(), G.ToString(), B.ToString());
        }

        public static LedColor OFF = new LedColor(0, 0, 0); 
        public static LedColor RED = new LedColor(0xFF, 0, 0);
        public static LedColor GREEN = new LedColor(0, 0xFF, 0);
        public static LedColor BLUE = new LedColor(0, 0, 0xFF);
        public static LedColor YELLOW = new LedColor(0xFF, 0xFF, 0);
        public static LedColor PURPLE = new LedColor(0xFF, 0, 0xFF);
        public static LedColor CYAN = new LedColor(0, 0xFF, 0xFF);
        public static LedColor WHITE = new LedColor(0xFF, 0xFF, 0xFF);


        public override bool Equals(Object o)
        {
            if (!(o is LedColor))
            {
                return false;
            }
            LedColor c = (LedColor)o;
            return R == c.R && G == c.G && B == c.B;
        }

        public override int GetHashCode()
        {
            int x = R;
            x = (x << 8) + G;
            x = (x << 8) + B;
            return (x);
        }

        public static bool operator ==(LedColor a, LedColor b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(LedColor a, LedColor b)
        {
            return !(a == b);
        }
        
    }
}
