using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.basics
{
    public struct Color
    {
        //public byte R;
        //public byte G;
        //public byte B;

        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
        }

        public static Color OFF = new Color(0, 0, 0); 
        public static Color RED = new Color(0xFF, 0, 0);
        public static Color GREEN = new Color(0, 0xFF, 0);
        public static Color BLUE = new Color(0, 0, 0xFF);

        public override bool Equals(Object o)
        {
            if (!(o is Color))
            {
                return false;
            }
            Color c = (Color)o;
            return R == c.R && G == c.G && B == c.B;
        }

        public override int GetHashCode()
        {
            int x = R;
            x = (x << 8) + G;
            x = (x << 8) + B;
            return (x);
        }

        public static bool operator ==(Color a, Color b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Color a, Color b)
        {
            return !(a == b);
        }
    }
}
