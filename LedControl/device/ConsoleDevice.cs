using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedControl.basics;

namespace LedControl.device
{
    public class ConsoleDevice : ILedDevice
    {
        struct ConsoleState
        {
            internal int x;
            internal int y;

            internal ConsoleColor color;
        }

        private bool isOpen = false;

        private int x;
        private int y;

        private Dictionary<string, ConsoleColor> colorDict = new Dictionary<string, ConsoleColor>();

        private ConsoleState state;

        private int ledWidth;

        public ConsoleDevice(int ledCount, int ledwidth = 1)
        {
            LedCount = ledCount;
            ledWidth = ledwidth;
            CreateColorDictionary();
            //Console.WriteLine(ConvertColor(new Color(100, 100, 140)));
        }

        private void CreateColorDictionary()
        {
            colorDict.Add("0000", ConsoleColor.Black);
            colorDict.Add("0001", ConsoleColor.DarkGray);
            colorDict.Add("0010", ConsoleColor.DarkBlue);
            colorDict.Add("0011", ConsoleColor.Blue);
            colorDict.Add("0100", ConsoleColor.DarkGreen);
            colorDict.Add("0101", ConsoleColor.Green);
            colorDict.Add("0110", ConsoleColor.DarkCyan);
            colorDict.Add("0111", ConsoleColor.Cyan);
            colorDict.Add("1000", ConsoleColor.DarkRed);
            colorDict.Add("1001", ConsoleColor.Red);
            colorDict.Add("1010", ConsoleColor.DarkMagenta);
            colorDict.Add("1011", ConsoleColor.Magenta);
            colorDict.Add("1100", ConsoleColor.DarkYellow);
            colorDict.Add("1101", ConsoleColor.Yellow);
            colorDict.Add("1110", ConsoleColor.Gray);
            colorDict.Add("1111", ConsoleColor.White);
        }

        public int LedCount
        {
            get;
            private set;
        }

        public ColorCorrection ColorCorrection
        {
            get;
            set;
        } = new ColorCorrection(1f, 1f, 1f);

        bool ILedDevice.IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        public void Close()
        {
            isOpen = false;
        }

        public void Open()
        {
            if (isOpen)
            {
                return;
            }
            isOpen = true;
            int width = LedCount * ledWidth + 4;
            if (Console.WindowWidth < width)
            {
                Console.WindowWidth = width;
            }


            if (Console.CursorLeft != 0) {
                Console.WriteLine();
            }
            Console.WriteLine("\n ConsoleDevice Output: {0}*{1} LEDs", LedCount, ledWidth);

            x = Console.CursorLeft + 2;
            y = Console.CursorTop + 1;

            char[,] border = new char[,] { { '╔', '═', '╗'  }, { '║', ' ', '║' }, { '╚', '═', '╝' } };

            for (int j = 0; j < 3; j++)
            {
                Console.Write(" ");
                Console.Write(border[j, 0]);
                for (int i = 0; i < LedCount * ledWidth; i++)
                {
                    Console.Write(border[j, 1]);
                }
                Console.WriteLine(border[j, 2]);
            }
        }

        public void Show(LedColor[] colors)
        {
            if (!isOpen)
            {
                return;
            }
            SaveConsoleState();
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < colors.Length; i++)
            {
                Console.ForegroundColor = ConvertColor(colors[i]);
                for (int j = 0; j < ledWidth; j++)
                {
                    Console.Write("*");
                }
            }
            RestoreConsoleState();
        }

        private void SaveConsoleState()
        {
            state.x = Console.CursorLeft;
            state.y = Console.CursorTop;
            state.color = Console.ForegroundColor;
        }

        private void RestoreConsoleState()
        {
            Console.SetCursorPosition(state.x, state.y);
            Console.ForegroundColor = state.color;
        }

        private ConsoleColor ConvertColor(LedColor color)
        {
            if (color == LedColor.OFF)
            {
                return ConsoleColor.Black;
            }
            int threshold = 100;
            char[] s = new char[] { ((color.R > 0) ? '1' : '0'), ((color.G > 0) ? '1' : '0'), ((color.B > 0) ? '1' : '0'), '0' };
            //Console.WriteLine(new string(s));
            if (!((color.R < threshold) && (color.G < threshold) && (color.B < threshold)))
            {
                s[3] = '1';
                s[0] = (color.R < 50) ? '0' : '1';
                s[1] = (color.G < 50) ? '0' : '1';
                s[2] = (color.B < 50) ? '0' : '1';
            } 
            //Console.WriteLine(new string(s));
            return colorDict[new string(s)];
        }
    }
}
