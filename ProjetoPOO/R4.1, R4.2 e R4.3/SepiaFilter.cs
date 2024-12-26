using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class SepiaFilter:BaseFilter
    {
        public SepiaFilter()
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
                    p.Red =(uint)(p.Red * 0.393 + p.Green * 0.769 + p.Blue * 0.189);
                    p.Green=(uint)(p.Red * 0.349 + p.Green * 0.686 + p.Blue *0.168);
                    p.Blue = (uint)(p.Red * 0.272 + p.Green * 0.534 + p.Blue * 0.131);
                    img.SetPixel(j, i, p.Red, p.Green, p.Blue);
                }
            }
        }
    }
}
