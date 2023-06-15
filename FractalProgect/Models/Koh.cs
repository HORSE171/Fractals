using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FractalProgect.Models
{
    public class Koh : Fractal
    {
        private int w;
        private int h;
        public Koh(int w, int h, int pokolenie) // Конструктор
        {
            this.pokolenie = pokolenie;
            this.w = w;
            this.h = h;
        }
        public override Bitmap Start(Graphics graphics) // МЕтод для создания фрактала
        {
            double angle = 180;
            double len = w;
            double x = w;
            double y = h / 2;
            Pen pen = new Pen(Color.Green, 2);
            Bitmap newBitmap = new Bitmap(w, h); // Создаем битмам, для дальнейшего его сохранения в файл
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                Create(g, pen, this.pokolenie, len, x, y, angle); // Вызов метода отрисовки и вычисления фрактала
            }

            if (!File.Exists($@"C:\img\koh\Koh{pokolenie}.png")) // Если файл не существует
            {
                newBitmap.Save($@"C:\img\koh\Koh{pokolenie}.png", ImageFormat.Png); // Мы создаем и сохраняем изображение с битмапа в файл ПНГ по указанному пути
            }
           
            return newBitmap;
        }

        private void Create(Graphics g, Pen pen, int level, double len, double x, double y, double angle) // Метод отрисовки и вычислений
        {
            if (level == 0)
            {
                double x2 = x + len * Math.Cos(angle * Math.PI / 180);
                double y2 = y + len * Math.Sin(angle * Math.PI / 180);
                g.DrawLine(pen, (float)x, (float)y, (float)x2, (float)y2);
            }
            else
            {
                len /= 3;
                Create(g, pen, level - 1, len, x, y, angle);
                x += len * Math.Cos(angle * Math.PI / 180);
                y += len * Math.Sin(angle * Math.PI / 180);
                angle += 60;
                Create(g, pen, level - 1, len, x, y, angle);
                x += len * Math.Cos(angle * Math.PI / 180);
                y += len * Math.Sin(angle * Math.PI / 180);
                angle -= 120;
                Create(g, pen, level - 1, len, x, y, angle);
                x += len * Math.Cos(angle * Math.PI / 180);
                y += len * Math.Sin(angle * Math.PI / 180);
                angle += 60;
                Create(g, pen, level - 1, len, x, y, angle);
            }
        }
    }
}
