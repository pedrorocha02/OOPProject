using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class BrightnessFilter: BaseFilter
    {
        int brightness;

        public BrightnessFilter(int brightness)
        {
            this.brightness = brightness;
        }

        public override void Apply(Image img)
        {
            int width = img.GetWidth();
            int heigth = img.GetHeigth();

            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < heigth; i++)
                {
                    Pixel p = img.GivePixel(j, i);
                    uint newred = Truncate(p.Red+brightness);
                    uint newgreen = Truncate(p.Green + brightness);
                    uint newblue = Truncate(p.Blue + brightness);
                    img.SetPixel(j, i, newred, newgreen, newblue);
                }
            }
        }

        static uint Truncate(long value)
        {
            if (value > 255)
                return 255;
            if (value < 0)
                return 0;
            return (uint)value;
        }
    }
}
