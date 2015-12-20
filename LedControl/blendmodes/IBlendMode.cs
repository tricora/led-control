using LedControl.basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.blendmodes
{
    public interface IBlendMode
    {
        Color Blend(Color[] colors);
    }
}
