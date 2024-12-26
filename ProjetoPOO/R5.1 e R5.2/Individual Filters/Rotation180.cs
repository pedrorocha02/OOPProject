using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class Rotation180:BaseFilter
    {
        public Rotation180()
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

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    img.SetPixel(i,j,copia[heigth - 1 - i, width - 1 - j]);
                }
            }
        }
    }
}
