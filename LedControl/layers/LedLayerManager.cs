using LedControl.basics;
using LedControl.blendmodes;
using LedControl.time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControl.layers
{
    public class LedLayerManager : LedSegment
    {
        private List<LedLayer> layers = new List<LedLayer>();

        public IBlendMode BlendMode { get; set; }

        public LedLayerManager()
        {
            BlendMode = new AverageBlendMode();
        }

        public LedLayerManager(IBlendMode blendMode)
        {
            BlendMode = blendMode;
        }

        protected override void OnUpdate(TimeData timeData)
        {
            //no layers added so we can skip updating
            if (layers.Count == 0)
            {
                return;
            }
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].Update(timeData);
            }
            if (layers.Count > 1)
            {
                Color[] colors = new Color[layers.Count];
                for (int i = 0; i < Leds.Length; i++)
                {
                    for (int j = 0; j < colors.Length; j++)
                    {
                        colors[j] = layers[j].Leds[i].Color;
                        Leds[i].Color = BlendMode.Blend(colors);
                    }
                }
            } else
            {
                for (int i = 0; i < Leds.Length; i++)
                {
                    Leds[i].Color = layers[0].Leds[i].Color;
                }
            }
        }

        public LedLayer CreateAndAddLayer()
        {
            Led[] layerLeds = new Led[Leds.Length];
            for (int i = 0; i < layerLeds.Length; i++)
            {
                layerLeds[i] = new Led();
            }
            LedLayer layer = new LedLayer(layerLeds);

            layers.Add(layer);

            return layer;
        }

        public void Remove(LedLayer layer)
        {
            layers.Remove(layer);
        }


    }


}
