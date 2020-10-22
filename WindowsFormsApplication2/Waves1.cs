using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class Waves1 : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = Clamp(((int)(x + (20 * Math.Sin(2 * Math.PI * x / 30)))), 0, sourceImage.Width - 1);
            int newY = Clamp((int)(y), 0, sourceImage.Height - 1);
            return sourceImage.GetPixel(newX, newY);
        }
    }
}
