using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class MedianFilter : BaseFilter
    {
        public MedianFilter()
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
                    if (j == 0 || i == 0 || j == width - 1 || i == heigth - 1)
                    {
                        continue;
                    }
                    else
                    {
                        Pixel p = copia[i, j - 1] + copia[i - 1, j] + copia[i + 1, j + 1] + copia[i + 1, j - 1] + copia[i - 1, j + 1] + copia[i, j + 1] + copia[i + 1, j] + copia[i - 1, j - 1] + copia[i - 1, j + 1];
                        img.SetPixel(i, j, p.Red / 9, p.Green / 9, p.Blue / 9);
                    }
                }
            }
        }
    }
}
        

 
        
        
        
        
        
