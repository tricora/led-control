using LedControl.basics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LedControl.device
{
    public interface ILedDevice
    {
        int LedCount { get; }
        bool IsOpen();
        ColorCorrection ColorCorrection { get; set; }

        void Open();
        void Close();
        void Show(Color[] colors);
    }
}