using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class Rotation:BaseFilter
    {
        int angle;

        public Rotation(int angle)
        {
            this.angle = angle;
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

            switch(angle)
                {
                case 0:
                    Rotation0(copia, img);
                    break;
                case 90:
                    Rotation90(copia, img);
                    break;
                case 180:
                    Rotation180(copia, img);
                    break;
                case 270:
                    Rotation270(copia, img);
                    break;
                default:
                    break;
            }
        }

        private static void Rotation0(Pixel [,] copia,Image img)
        {
            int width = img.GetWidth();
            int heigth = img.GetHeigth();

            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < heigth; i++)
                {
                    img.SetPixel(i, j, copia[j, i]);
                }
            }
            
        }

        private static void Rotation90(Pixel[,] copia, Image img)
        {
            int width = img.GetWidth();
            int heigth = img.GetHeigth();

            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < heigth; i++)
                {
                    img.SetPixel(width - j - 1, i, copia[j,i]); 
                }
            }
        }

        private static void Rotation180(Pixel[,] copia, Image img)
        {
            int width = img.GetWidth();
            int heigth = img.GetHeigth();

            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < heigth; i++)
                {
                    img.SetPixel(i, j, copia[heigth - 1 - i, width - 1 - j]);
                }
            }
        }

        private static void Rotation270(Pixel[,] copia, Image img)
        {
            int width = img.GetWidth();
            int heigth = img.GetHeigth();

            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < heigth; i++)
                {
                    Pixel p = copia[j, i];
                    img.SetPixel(j, heigth - i - 1, p);
                }
            }
        }
    }
}
