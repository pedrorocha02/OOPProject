using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class Rotation0:BaseFilter
    {
        public Rotation0()
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
                    img.SetPixel(i,j,copia[j, i]);
                }
            }
        }
    }
}
