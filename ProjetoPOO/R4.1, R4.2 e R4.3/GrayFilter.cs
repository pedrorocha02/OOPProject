using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class GrayFilter:BaseFilter
    {
       
        public GrayFilter()
        {
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
                    img.SetPixel(j, i, avg, avg, avg);
                }
            }
        }
    }
}
