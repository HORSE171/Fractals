using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FractalProgect.Models
{
    public class Serpinski : Fractal
    {
        private int w;
        private int h;
        public Serpinski(int w, int h, int pokolenie)
        {
            this.pokolenie = pokolenie;
            this.w = w;
            this.h = h;
        }
        public override Bitmap Start(Graphics graphics)
        {
            RectangleF rectangleF = new RectangleF(0, 0, this.w, this.h);
            Bitmap newBitmap = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                Create(g, this.pokolenie, rectangleF);
            }
            if (!File.Exists($@"C:\img\serpinski\Serpinski{pokolenie}.png")) //Если файл не существует
            {
                newBitmap.Save($@"C:\img\serpinski\Serpinski{pokolenie}.png", ImageFormat.Png); // Сохраняем изображение по указанному пути
            }
           
            return newBitmap;
        }

        private void Create(Graphics gr, int level, RectangleF rect) // Метод вычислений и отрисовки
        {
            // Посмотрим, остановимся ли мы.
            if (level == 0)
            {
                // Заполните прямоугольник.
                gr.FillRectangle(Brushes.Green, rect);
            }
            else
            {
                // Разделим прямоугольник на 9 частей.
                float wid = rect.Width / 3f;
                float x0 = rect.Left;
                float x1 = x0 + wid;
                float x2 = x0 + wid * 2f;

                float hgt = rect.Height / 3f;
                float y0 = rect.Top;
                float y1 = y0 + hgt;
                float y2 = y0 + hgt * 2f;

                // Рекурсивно рисуем меньшие ковры.
                Create(gr, level - 1, new RectangleF(x0, y0, wid, hgt));
                Create(gr, level - 1, new RectangleF(x1, y0, wid, hgt));
                Create(gr, level - 1, new RectangleF(x2, y0, wid, hgt));
                Create(gr, level - 1, new RectangleF(x0, y1, wid, hgt));
                Create(gr, level - 1, new RectangleF(x2, y1, wid, hgt));
                Create(gr, level - 1, new RectangleF(x0, y2, wid, hgt));
                Create(gr, level - 1, new RectangleF(x1, y2, wid, hgt));
                Create(gr, level - 1, new RectangleF(x2, y2, wid, hgt));
            }
        }
    }
}
