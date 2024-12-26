using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    class SaturationFilter : BaseFilter
    {
        uint percentage;
        public SaturationFilter(uint percentage)
        {
            this.percentage = percentage;
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
                    Pixel p = copia[i, j];
                    p.Saturation = percentage;
                    img.SetPixel(i,j,RgbToHsi(p.Red, p.Green, p.Blue));
                }
            }
        }

        private static Pixel RgbToHsi(uint red,uint green,uint blue)
        {
            uint max = red;
            uint min = red;

            if (green > max)
                max = green;
            if (green < min)
                min = green;
            if (blue > max)
                max = blue;
            if (blue < min)
                min = blue;

             uint C = max - min;

             uint H=0;

            if (C == 0)
                H = 0;
            else if (max == red)
                H = 60 * ((green - blue) / C) % 6;
            else if (max == red)
                H = 60 * ((blue - red) / C) + 2;
            else if (max == red)
                H = 60 * ((red - green) / C) + 4;

            uint I = (red + blue + green) / 3;

            uint S = 0;

            if (I == 0)
                S = 0;
            else if (I != 0)
                S = 1 - min / I;

            return HsiToRgb(H, S, I);
            
        }

        private static Pixel HsiToRgb(uint H,uint S,uint I)
        {
            uint m = I * (1 - S);

            uint Z = 1 -(((H / 60) % 2) - 1);
            uint C = (2 * I * S) / (1 + Z);
            uint X = C * Z;

            if (H <= 60)
                return new Pixel(C+m, X+m, 0+m);
            else if (H <= 120)
                return new Pixel(X+m, C+m, 0+m);
            else if (H <= 180)
                return new Pixel(0+m, C+m, X+m);
            else if (H <= 240)
                return new Pixel(0+m, X+m, C+m);
            else if (H <= 300)
                return new Pixel(X+m, 0+m, C+m);
            else if (H <= 360)
                return new Pixel(C+m, X+m, 0+m);
            else
                return new Pixel(0+m, 0+m, 0+m);
               
        }
    }
}
