using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FractalProgect.Models
{
    public class Krug : Fractal
    {
        private int w;
        private int h;
        public Krug(int w, int h, int pokolenie)
        {
            this.pokolenie = pokolenie;
            this.w = w;
            this.h = h;
        }
        public override Bitmap Start(Graphics graphics)
        {
            Bitmap newBitmap = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.FillRectangle(Brushes.Black, 0, 0, this.w, this.h);
                Create(g, w / 2, h / 2, w / 2 - 20, this.pokolenie);
            }

            if (!File.Exists($@"C:\img\krug\Krug{pokolenie}.png")) // Если файл не существует
            {
                newBitmap.Save($@"C:\img\krug\Krug{pokolenie}.png", ImageFormat.Png); // Сохраняем битмапа в файл по указаннному пути
            }
            return newBitmap;
        }

        private void Create(Graphics g, int x, int y, int size, int lvl) // Метод отрисовки и вычислений фрактала
        {
            Pen p = new Pen(Color.Green);
            int iter = lvl, a = 3;
            int r1, r2;

            if (size > 1)
            {
                r1 = (int)Math.Round(size / (a * 1.0));
                r2 = (int)Math.Round(size * (a - 1.0) / a);
                Create(g, x, y, r1, lvl);
                for (int i = 1; i <= iter; i++)
                    Create(g, x - (int)Math.Round(r2 * Math.Sin(2 * Math.PI / iter * i)), y + (int)Math.Round(r2 * Math.Cos(2 * Math.PI / iter * i)), r1, lvl);

            }
            g.DrawEllipse(p, x - size, y - size, 2 * size, 2 * size);
        }
    }
}
