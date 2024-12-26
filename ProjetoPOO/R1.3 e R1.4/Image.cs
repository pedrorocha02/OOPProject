using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ppo
{
    class Image
    {
        int width;
        int heigth;
        Pixel[,] data;

        public Image(int width,int heigth)
        {
            this.heigth = heigth;
            this.width = width;
            
            data = new Pixel[heigth, width];
        }

        public bool Ler(BinaryReader br)
        {
            uint red;
            uint green;
            uint blue;

            try
            {
                for (int j = 0; j < heigth; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        red = br.ReadByte();
                        green = br.ReadByte();
                        blue = br.ReadByte();
                        data[j, i] = new Pixel(red, green, blue);
                    }
                }
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }

        public void SetPixel(int i,int j, uint r,uint g,uint b)
        {
            data[j,i].SetValues(r, g, b);
        }

        public void SetPixel(int i, int j,Pixel p)
        {
             data[j,i].SetValues(p);
        }

        public Pixel GivePixel(int j,int i)
        {
            return data[j, i];
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeigth()
        {
            return heigth;
        }

        public bool Write(BinaryWriter bw)
        {
            try
            {
                for (int j = 0; j < heigth; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        Pixel p = data[j, i];
                        bw.Write(p.Red);
                        bw.Write(p.Green);
                        bw.Write(p.Blue);
                    }
                }
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }

        public override string ToString()
        {
            string str = "\n\n";
            for (int j = 0; j < heigth; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    str += data[j, i].ToString();
                }
                str += "\n";
            }
            return str;
        }
    }
}
