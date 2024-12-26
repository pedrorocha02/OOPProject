using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class Rotation270 : BaseFilter
    {
        public Rotation270()
        {
        }

        public override void Apply(Image img)
        {
            int width = img.GetWidth();
            int heigth = img.GetHeigth();

            Pixel[,] copia = new Pixel[width, heigth];

            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < heigth; i++)
                {
                    copia[j, i] = img.GivePixel(j, i);
                }
            }
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < heigth; i++)
                {
                    Pixel p = copia[j, i];
                    img.SetPixel(j,heigth-i-1,p);
                }
            }
        }
    }
}
