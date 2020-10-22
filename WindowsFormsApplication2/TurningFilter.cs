using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
namespace WindowsFormsApplication2
{
    class TurningFilter : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int x0 = sourceImage.Width / 2;
            int y0 = sourceImage.Height / 2;
            double M = Math.PI / 3;
            int newX = Clamp((int)((x - x0) * Math.Cos(M) - (y-y0) * Math.Sin(M) + x0), 0, sourceImage.Width - 1);
            int newY = Clamp((int)((x - x0) * Math.Sin(M) + (y - y0) * Math.Cos(M) + y0), 0, sourceImage.Height - 1);
            return sourceImage.GetPixel(newX, newY);
        }
    }
}
