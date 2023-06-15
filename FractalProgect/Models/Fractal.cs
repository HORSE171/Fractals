using System.Drawing;

namespace FractalProgect.Models
{
    public abstract class Fractal
    {
        protected int pokolenie;

        private Point[] points;


        public virtual Bitmap Start(Graphics graphics) // Базовая версия метода для создания фрактала
        {
            return null;
        }
    }
}
