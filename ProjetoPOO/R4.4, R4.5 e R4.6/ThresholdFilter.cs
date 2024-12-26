using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class ThresholdFilter: BaseFilter
    {
        int l;

        public ThresholdFilter(int l)
        {
            this.l = l;
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
                    uint avg = (p.Red + p.Green + p.Blue) / 3;
                    uint value = Truncate(avg, l);
                    img.SetPixel(j, i, value, value, value);
                }
            }
        }
        
        static uint Truncate(uint avg,int l)
        {
            if (avg > l)
                return 255;
            if (avg < l)
                return 0;
            return avg;
        }
    }
}
