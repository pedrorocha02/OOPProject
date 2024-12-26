using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class ContrastFilter : BaseFilter
    {
        int value;
        public ContrastFilter(int value)
        {
            this.value = value;
        }

        public override void Apply(Image img)
        {
            ImageHeader ih = new ImageHeader();
            int width = ih.GetWidth();
            int heigth = ih.GetHeigth();

            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < heigth; i++)
                {
                    Pixel p = img.GivePixel(j, i);
                    int f = 259 * (value + 255)/(255 * (259 - value));
                    uint newred = Truncate(f * (p.Red - 128) + 128);
                    uint newgreen = Truncate(f * (p.Red - 128) + 128);
                    uint newblue = Truncate(f * (p.Red - 128) + 128);
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
