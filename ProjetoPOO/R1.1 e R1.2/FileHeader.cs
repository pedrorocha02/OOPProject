using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ppo
{
    class FileHeader
    {
        UInt16 bfType;
        UInt32 bfSize;
        UInt16 bfReserved1;
        UInt16 bfReserved2;
        UInt32 bfOffBits;

        public FileHeader()  
        {
            bfType = 0;
            bfSize = 0;
            bfReserved1 = 0;
            bfReserved2 = 0;
            bfOffBits = 0;
        }

        public FileHeader(UInt16 bfType, UInt32 bfSize, UInt16 bfReserved1, UInt16 bfReserved2, UInt32 bfOffBits) //Construtor por parâmetros
        {
            this.bfType = bfType;
            this.bfSize = bfSize;
            this.bfReserved1 = bfReserved1;
            this.bfReserved2 = bfReserved2;
            this.bfOffBits = bfOffBits;
        }

        public FileHeader(FileHeader fh) 
        {
            bfType = fh.bfType;
            bfSize = fh.bfSize;
            bfReserved1 = fh.bfReserved1;
            bfReserved2 = fh.bfReserved2;
            bfOffBits = fh.bfOffBits;
        }

        public bool Ler(BinaryReader br)
        {
            try
            {
                bfType = br.ReadUInt16();
                bfSize = br.ReadUInt32();
                bfReserved1 = br.ReadUInt16();
                bfReserved2 = br.ReadUInt16();
                bfOffBits = br.ReadUInt32();
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }

        public bool Validate(BinaryReader br)
        {
            if (bfType != 19778)
                return false;
            if (bfOffBits != 54)
                return false;
            if (bfReserved1 != 0)
                return false;
            if (bfReserved2 != 0)
                return false;
            return true;
        }

        public bool Write(BinaryWriter bw)
        {
            try
            {
                bw.Write(bfType);
                bw.Write(bfSize);
                bw.Write(bfReserved1);
                bw.Write(bfReserved2);
                bw.Write(bfOffBits); 
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
            sb.AppendFormat("File Type:{0}", bfType);
            sb.AppendFormat("\nFile Size:{0}",bfSize);
            sb.AppendFormat("\nReserved1:{0}", bfReserved1);
            sb.AppendFormat("\nReserved2:{0}", bfReserved2);
            sb.AppendFormat("\n\nOffset Bits:{0}", bfOffBits);
            return sb.ToString();
        }
    }
}
