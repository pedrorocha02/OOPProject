using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ppo
{
    class ImageHeader
    {
        UInt32 biSize;
        Int32 biWidth;
        Int32 biHeight;
        UInt16 biPlanes;
        UInt16 biBitCount;
        UInt32 biCompression;
        UInt32 biSizeImage;
        Int32 biXPelsPerMeter;
        Int32 biYPelsPerMeter;
        UInt32 biClrUsed;
        UInt32 biClrImportant;

        public ImageHeader()
        {
            biSize = 0;
            biWidth = 0;
            biHeight = 0;
            biPlanes = 0;
            biBitCount = 0;
            biCompression = 0;
            biSizeImage = 0;
            biXPelsPerMeter = 0;
            biYPelsPerMeter = 0;
            biClrUsed = 0;
            biClrImportant = 0;
        }

        public ImageHeader(UInt32 biSize, Int32 biWidth, Int32 biHeight, UInt16 biPlanes, UInt16 biBitCount, UInt32 biCompression, UInt32 biSizeImage, Int32 biXPelsPerMeter, Int32 biYPelsPerMeter, UInt32 biClrUsed, UInt32 biClrImportant)
        {
            this.biSize = biSize;
            this.biWidth = biWidth;
            this.biHeight = biHeight;
            this.biPlanes = biPlanes;
            this.biBitCount = biBitCount;
            this.biCompression = biCompression;
            this.biSizeImage = biSizeImage;
            this.biXPelsPerMeter = biXPelsPerMeter;
            this.biYPelsPerMeter = biYPelsPerMeter;
            this.biClrUsed = biClrUsed;
            this.biClrImportant = biClrImportant;

        }

        public ImageHeader(ImageHeader ih) 
        {
            biSize = ih.biSize;
            biWidth = ih.biWidth;
            biHeight = ih.biHeight;
            biPlanes = ih.biPlanes;
            biBitCount = ih.biBitCount;
            biCompression = ih.biCompression;
            biSizeImage = ih.biSizeImage;
            biXPelsPerMeter = ih.biXPelsPerMeter;
            biYPelsPerMeter = ih.biYPelsPerMeter;
            biClrUsed = ih.biClrUsed;
            biClrImportant = ih.biClrImportant;
        }

        public int GetWidth()
        {
            return biWidth;
        }

        public int GetHeigth()
        {
            return biHeight;
        }

        public bool Ler(BinaryReader br)
        {
            try
            {
                biSize = br.ReadUInt32();
                biWidth = br.ReadInt32();
                biHeight = br.ReadInt32();
                biPlanes = br.ReadUInt16();
                biBitCount = br.ReadUInt16();
                biCompression = br.ReadUInt32();
                biSizeImage = br.ReadUInt32();
                biXPelsPerMeter = br.ReadInt32();
                biYPelsPerMeter = br.ReadInt32();
                biClrUsed = br.ReadUInt32();
                biClrImportant = br.ReadUInt32();
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }

        public bool Validate(BinaryReader br)
        {
            if (biWidth <= 0)
                return false;
            if (biHeight <= 0)
                return false;
            if (biSize != 40)
                return false;
            if (biPlanes != 1)
                return false;
            if (!(biBitCount == 24))
                return false;
            if (biCompression != 0)
                return false;
            return true;
        }

        public bool Write(BinaryWriter bw)
        {
            try
            {
                bw.Write(biSize);
                bw.Write(biWidth);
                bw.Write(biHeight);
                bw.Write(biPlanes);
                bw.Write(biBitCount);
                bw.Write(biCompression);
                bw.Write(biSizeImage);
                bw.Write(biXPelsPerMeter);
                bw.Write(biYPelsPerMeter);
                bw.Write(biClrUsed);
                bw.Write(biClrImportant);
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Image header size: {0}", biSize);
            sb.AppendFormat("\nImage width: {0}", biWidth);
            sb.AppendFormat("\nImage height: {0}", biHeight);
            sb.AppendFormat("\nImage colour planes: {0}", biPlanes);
            sb.AppendFormat("\nImage bit count per pixel: {0}", biBitCount);
            sb.AppendFormat("\nImage compression: {0}", biCompression);
            sb.AppendFormat("\nImage size: {0}", biSizeImage);
            sb.AppendFormat("\nImage x pels per meter: {0}", biXPelsPerMeter);
            sb.AppendFormat("\nImage y pels per meter: {0}", biYPelsPerMeter);
            sb.AppendFormat("\nImage clr used: {0}", biClrUsed);
            sb.AppendFormat("\nImage clr important: {0}", biClrImportant);
            return sb.ToString();
        }
    }
}
