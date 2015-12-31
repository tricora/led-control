using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.device
{
    public class LedDeviceManager : HashSet<ILedDevice>
    {
        public void OpenAll()
        {
            foreach (ILedDevice dev in this)
            {
                dev.Open();
            }
        }

        public void CloseAll()
        {
            foreach (ILedDevice dev in this)
            {
                dev.Close();
            }
        }
    }
}
