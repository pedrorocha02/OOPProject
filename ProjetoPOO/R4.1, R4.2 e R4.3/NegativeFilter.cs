using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class NegativeFilter:BaseFilter
    {
        public NegativeFilter()
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
                    img.SetPixel(j, i, 255 - p.Red, 255 - p.Green, 255 - p.Blue);
                }
            }
        }
    }
}
