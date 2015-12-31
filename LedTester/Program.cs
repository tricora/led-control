using LedControl;
using LedControl.basics;
using LedControl.device;
using LedControl.layers;
using LedControl.segments;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedTester
{
    class Program
    {

        static volatile Boolean isInterrupted = false;

        static void Main(string[] args)
        {

            Thread thread = new Thread(() =>
            {
                LedController ledController = null;
                try
                {
                    int LED_COUNT = 50;

                    ledController = new LedController(LED_COUNT);

                    ILedDevice consoleDevice = new ConsoleDevice(LED_COUNT, 3);
                    ILedDevice serialDevice = new SerialDevice("COM3", LED_COUNT);
                    ledController.LedDeviceManager.Add(serialDevice);
                    ledController.LedDeviceManager.Add(consoleDevice);

                    ledController.LedDeviceManager.OpenAll();
                    

                    //ledController.Brightness = 0.5f;

                    MMDeviceEnumerator devices = new MMDeviceEnumerator();

                    MMDevice device = devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

                    LedLayer layer = ledController.LedLayerManager.CreateAndAddLayer();

                    LedSegment leftAudio = new AudioSegment(device, AudioMode.LEFT);
                    leftAudio.Delay = 0;
                    layer.Add(leftAudio, 0, 24);
                    layer.Add(new AudioSegment(device, AudioMode.RIGHT), 49, 25);

                    //layer.Add(new BinaryWatchSegment(), 24, 26);

                    //layer.Add(new FlickerSegment(), 24, 24);
                    //layer.Add(new SimpleLedSegment(), 25, 25);

                    //LedLayer layer2 = ledController.LedLayerManager.CreateAndAddLayer();
                    //layer2.Add(new NightRiderSegment(new Color(0, 50, 50)), 0, 49);

                    while (!isInterrupted)
                    {
                        ledController.Update();
                        Thread.Sleep(20);
                    }

                    ledController.TurnOff();
                    

                    Console.WriteLine("Thread finished");
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                } finally
                {
                    if (ledController != null) { ledController.LedDeviceManager.CloseAll(); }
                }
                
            });

            thread.Start();

            Console.WriteLine("Press key to exit...");
            Console.ReadKey();
            
            isInterrupted = true;
            thread.Join();
            Console.WriteLine("done");
        }
    }
}

