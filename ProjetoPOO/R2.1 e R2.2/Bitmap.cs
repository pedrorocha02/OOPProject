using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ppo
{
    class Bitmap
    {
        FileHeader fh;
        ImageHeader ih;
        Image i;

        public bool Read(string caminho)
        {
            BinaryReader br;
            try
            {
                br = new BinaryReader(new FileStream(caminho, FileMode.Open));
            }
            catch (IOException e)
            {
                return false;
            }

            fh = new FileHeader();
            if(!fh.Ler(br))
            {
                return false;
            }

            if (!fh.Validate(br))
            {
                return false;
            }

            ih = new ImageHeader();

            if(!ih.Ler(br))
            {
                return false;
            }

            if (!ih.Validate(br))
            {
                return false;
            }

            i = new Image(ih.GetWidth(), ih.GetHeigth());

            if(!i.Ler(br))
            {
                return false;
            }
            return true;
        }

        public bool Write(string caminho)
        {
            BinaryReader br;
            try
            {
                br = new BinaryReader(new FileStream(caminho, FileMode.Open));
            }
            catch (IOException e)
            {
                return false;
            }

            if (!ih.Ler(br))
            {
                return false;
            }

            if(!fh.Ler(br))
            {
                return false;
            }

            if(!i.Ler(br))
            {
                return false;
            }
            return true;
        }

        public Image GetImage()
        {
            return i;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(fh.ToString());
            sb.Append(ih.ToString());
            sb.Append(i.ToString());
            return sb.ToString();
        }

        public Pixel GetPixel(int i, int j,Image img)
        {
            Pixel p = img.GivePixel(i, j);
            return p;
        }
    }
}
