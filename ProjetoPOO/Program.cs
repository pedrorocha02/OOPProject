using System;
using System.IO;

namespace ppo
{
    class Program
    {
        static void Main(string[] args)
        {
            string ficheiro = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\teste.txt";
            StreamWriter sw = new StreamWriter(ficheiro);

            //Console.WriteLine("Introduza o nome da imagem em .bmp que deseja ler:");
            //string caminho = Console.ReadLine();
            string caminho = "bmp8x8.bmp";

            //BinaryReader br;
            //try
            //{
            //    br = new BinaryReader(new FileStream(imagem, FileMode.Open)); 
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message + "\n Cannot open file.");
            //    sw.WriteLine(e.Message + "\n Cannot open file.");
            //    return;
            //}

            Bitmap bmp = new Bitmap();

            if(!bmp.Read(caminho))
            {
                return;
            }

            Console.WriteLine(bmp.ToString());

            Image img = bmp.GetImage();
            //img.SetPixel(0, 0, 255, 0, 0);

            BaseFilter vertical = new Rotation90();
            vertical.Apply(img);
            bmp.Read(caminho);
            bmp.Write(caminho);
            Console.WriteLine(bmp);

            //BaseFilter rf = new RedFilter();
            //rf.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter gf = new GreenFilter();
            //gf.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter bf = new BlueFilter();
            //bf.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter satredfil = new SaturationRedFilter();
            //satredfil.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter satgreenfil = new SaturationGreenFilter();
            //satgreenfil.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter satbluefil = new SaturationBlueFilter();
            //satbluefil.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter neg = new NegativeFilter();
            //neg.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter thershold = new ThresholdFilter(0);
            //thershold.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter gray = new GrayFilter();
            //gray.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter bright = new BrightnessFilter(255);
            //bright.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);

            //BaseFilter contrast  = new ContrastFilter(255);
            //contrast.Apply(img);
            //bmp.Read(caminho);
            //bmp.Write(caminho);
            //Console.WriteLine(bmp);








            //FileHeader fh = new FileHeader();
            //if (!fh.Ler(br))
            //{
            //    Console.WriteLine("Ocorreu um Erro ao ler o FileHeader!");
            //    sw.WriteLine("Ocorreu um Erro ao ler o FileHeader!");
            //    return;
            //}

            //if (!fh.Validate(br))
            //{
            //    Console.WriteLine("Ocorreu um erro ao ler a imagem!");
            //    sw.WriteLine("Ocorreu um erro ao ler a imagem!");
            //    return;
            //}

            //Console.WriteLine(fh);
            //sw.WriteLine(fh);

            //ImageHeader ih = new ImageHeader();
            //if (!ih.Ler(br))
            //{
            //    Console.WriteLine("Ocorreu um Erro ao ler o ImageHeader!");
            //    sw.WriteLine("Ocorreu um Erro ao ler o ImageHeader!");
            //    return;
            //}

            //if (!ih.Validate(br))  
            //{
            //    Console.WriteLine("Ocorreu um erro ao ler a Imagem ");
            //    sw.WriteLine("Ocorreu um erro ao ler a Imagem ");
            //    return;
            //}

            //Console.WriteLine(ih);
            //sw.WriteLine(ih);

            //Image ig = new Image(ih.GetWidth(), ih.GetHeigth());

            //if (!ig.Ler(br))
            //{
            //    Console.WriteLine("Ocorreu um Erro ao ler a Imagem!");
            //    sw.WriteLine("Ocorreu um Erro ao ler a Imagem!");
            //    return;
            //}

            //Console.WriteLine(ig); 
            //sw.WriteLine(ig);
            //br.Close();
            sw.Close();
        }
    }
}



