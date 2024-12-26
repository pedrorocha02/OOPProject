using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ppo
{
    class Pixel
    {
        //uint red;
        public uint Red { get; set;}
        //uint green;
        public uint Green { get; set; }
        //uint blue;
        public uint Blue { get; set; }

        public uint Saturation { get; set; }

        public Pixel () 
        {
            Red = 0;
            Green = 0;
            Blue = 0;
        }

        public Pixel(uint red, uint green, uint blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public Pixel(Pixel p)
        {
            Red = p.Red;
            Green = p.Green;
            Blue = p.Blue;
        }

        public void SetValues(uint red, uint green, uint blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public void SetValues(Pixel p)
        {
            Red = p.Red;
            Green = p.Green;
            Blue = p.Blue;
        }

        public uint GetRed()
        {
            return Red;
        }

        public uint GetGreen()
        {
            return Green;
        }

        public uint GetBlue ()
        {
            return Blue;
        }

        public static Pixel operator +(Pixel left,Pixel right)
        {
            uint red = left.Red + right.Red;
            uint green = left.Green + right.Green;
            uint blue = left.Blue + right.Blue;

            return new Pixel(red, green, blue);
        }

        public override string ToString()
        {
            return String.Format("[{0:X2}, {0:X2}, {0:X2}] ", Red, Green, Blue);
        }
    }
}
