using LedControl;
using LedControl.basics;
using LedControl.device;
using LedControl.layers;
using LedControl.segments;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedColorChooser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Color oldColor = Properties.Settings.Default.color;
            ColorDialog dialog = new ColorDialog();
            dialog.FullOpen = true;
            dialog.Color = oldColor;
            var result = dialog.ShowDialog();

            int LED_COUNT = 50;

            LedController controller = new LedController(LED_COUNT);

            ILedDevice serialDevice = new SerialDevice("COM3", LED_COUNT);

            serialDevice.ColorCorrection = new ColorCorrection(1.0f, 0.5f, 0.6f);

            controller.LedDeviceManager.Add(serialDevice);

            controller.LedDeviceManager.OpenAll();


            if (result == DialogResult.OK)
            {
                LedLayer layer = controller.LedLayerManager.CreateAndAddLayer();

                var segment = new StaticSegment(new LedColor(oldColor));

                layer.Add(segment, 0, LED_COUNT - 1);

                Fade(controller, segment, oldColor, dialog.Color);

                segment.color = new LedColor(dialog.Color);
                controller.Update();

                SaveColor(dialog.Color);
            }
            else
            {
                controller.TurnOff();
                SaveColor(Color.Black);
            }

            controller.LedDeviceManager.CloseAll();
        }

        private static void Fade(LedController controller, StaticSegment segment, Color from, Color to)
        {

            for (var i = 0; i < 256; i++)
            {
                Thread.Sleep(10);
                double scale = (double) i / 255.0;
                
                Color ledColor = Color.FromArgb(1, Interpolate(from.R, to.R, scale), Interpolate(from.G, to.G, scale), Interpolate(from.B, to.B, scale));
                
                segment.color = new LedColor(ledColor);
                controller.Update();

                SaveColor(ledColor);
            }
        }

        private static byte Interpolate(byte from, byte to, double val)
        {
            double result = (from + (to - from) * val);
            return Convert.ToByte(result);
        }

        private static void SaveColor(Color color)
        {
            Properties.Settings.Default.color = color;
            Properties.Settings.Default.Save();
        }
    }
}
