using LedControl.basics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedControl.device
{
    public class SerialDevice : ILedDevice
    {
        public int LedCount { get; private set; }

        private SerialPort serialPort;
        private byte[] buf;

        public ColorCorrection ColorCorrection
        {
            get;
            set;
        } = new ColorCorrection(1f, 1f, 1f);

        bool ILedDevice.IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }

        public SerialDevice(string port, int ledCount)
        {
            serialPort = new SerialPort();
            serialPort.PortName = port;
            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;

            LedCount = ledCount;
            
            buf = new byte[LedCount * 3 + 1];
            buf[0] = 0xFF;
        }

        public void Open()
        {
            serialPort.Open();
        }

        public void Close()
        {
            if (serialPort != null) {
                Thread.Sleep(100);
                try
                {
                    serialPort.Close();
                }
                catch (Exception)
                {
                    serialPort.Dispose();
                }
        }

            
        }

        

        public void Show(Color[] colors)
        {
            if (!serialPort.IsOpen)
            {
                return;
            }
            for (int i = 0; i < Math.Min(colors.Length, LedCount); i++)
            {
                buf[i * 3 + 1] = ToByteAndClamp(colors[i].R * ColorCorrection.R);
                buf[i * 3 + 2] = ToByteAndClamp(colors[i].G * ColorCorrection.G);
                buf[i * 3 + 3] = ToByteAndClamp(colors[i].B * ColorCorrection.B);
            }

            serialPort.Write(buf, 0, buf.Length);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte ToByteAndClamp(float v)
        {
            return (byte)Math.Min(0xFE, v);
        }
    }
}
