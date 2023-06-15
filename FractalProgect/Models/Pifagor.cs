using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FractalProgect.Models
{
    public class Pifagor : Fractal
    {
        private int w;
        private int h;
        private int wind;
        public Pifagor(int w, int h, int pokolenie, int wind)
        {
            this.pokolenie = pokolenie;
            this.w = w;
            this.h = h;
            this.wind = wind;
        }
        public override Bitmap Start(Graphics graphics)
        {
            Bitmap newBitmap = new Bitmap(w, h);
            try
            {
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    Create(g, this.pokolenie, w / 2, h, 90, 140);
                }
                if (this.wind != 0)
                {
                    if (!File.Exists($@"C:\img\wind\Pif_{pokolenie}_{wind}.png")) // Если файл не существует
                        newBitmap.Save($@"C:\img\wind\Pif_{pokolenie}_{wind}.png", ImageFormat.Png); // Сохраняем изображение по указанному пути
                }
                else
                {
                    if (!File.Exists($@"C:\img\pif\Pif{pokolenie}.png")) // Если файл не существует
                        newBitmap.Save($@"C:\img\pif\Pif{pokolenie}.png", ImageFormat.Png); // Сохраняем изображение по указанному пути

                    if (!File.Exists($@"C:\img\wind\Pif_{pokolenie}_{wind}.png")) // Если файл не существует
                        newBitmap.Save($@"C:\img\wind\Pif_{pokolenie}_{wind}.png", ImageFormat.Png); // Сохраняем изображение по указанному пути
                }
               
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
           
            return newBitmap;
        }

        private void Create(Graphics gr, int level, int x, int y, double angle, int length) // Метод отрисовки и вычислений фрактала
        {
            if (level == 0)
            {
                return;
            }

            int x2 = x + (int)(length * Math.Cos(angle * Math.PI / 180.0));
            int y2 = y - (int)(length * Math.Sin(angle * Math.PI / 180.0));

            Pen pen = new Pen(Color.Green, 2);
            gr.DrawLine(pen, x, y, x2, y2);

            int n1 = 0;
            int n2 = 0;
            if (this.wind >=0)
            {
                n1 = 45;
                n2 = n1 - this.wind * 10;
            }
            else
            {
                n2 = 45;
                n1 = n2 - this.wind * -10;
            }
            Create(gr, level - 1, x2, y2, angle - n1, length - length / 3);
            Create(gr, level - 1, x2, y2, angle + n2, length - length / 3);

        }
    }
}
