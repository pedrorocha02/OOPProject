using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class SharpenFilter : BaseFilter
    {
        public SharpenFilter()
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
                    if(j==0|| i==0||j==width-1 || i==heigth-1)
                    {
                        continue;
                    }
                    else
                    {
                        Pixel p = new Pixel();
                        p.Red = copia[i - 1, j - 1].Red * (-1 / 9) + copia[i - 1, j].Red * (-1 / 9) + copia[i - 1, j + 1].Red * (-1 / 9) + copia[i , j - 1].Red * (-1 / 9) + copia[i, j].Red * (8 / 9) + copia[i , j +1].Red * (-1 / 9) + copia[i + 1, j - 1].Red * (-1 / 9) + copia[i + 1, j].Red * (-1 / 9) + copia[i + 1, j + 1].Red * (-1 / 9);
                        p.Green= copia[i - 1, j - 1].Green * (-1 / 9) + copia[i - 1, j].Green * (-1 / 9) + copia[i - 1, j + 1].Green * (-1 / 9) + copia[i, j - 1].Green * (-1 / 9) + copia[i, j].Green * (8 / 9) + copia[i, j + 1].Green * (-1 / 9) + copia[i + 1, j - 1].Green * (-1 / 9) + copia[i + 1, j].Green * (-1 / 9) + copia[i + 1, j + 1].Green * (-1 / 9);
                        p.Blue= copia[i - 1, j - 1].Blue * (-1 / 9) + copia[i - 1, j].Blue * (-1 / 9) + copia[i - 1, j + 1].Blue * (-1 / 9) + copia[i, j - 1].Blue * (-1 / 9) + copia[i, j].Blue * (8 / 9) + copia[i, j + 1].Blue * (-1 / 9) + copia[i + 1, j - 1].Blue * (-1 / 9) + copia[i + 1, j].Blue * (-1 / 9) + copia[i + 1, j + 1].Blue * (-1 / 9);
                        img.SetPixel(i, j, p.Red,p.Green,p.Blue);
                    }
                }
            }

        }
    }
}
