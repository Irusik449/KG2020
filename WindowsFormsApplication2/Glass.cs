using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace WindowsFormsApplication2
{
    class Glass : Filters
    {
        Random rand = new Random();
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = Clamp((int)(x + (rand.NextDouble() - 0.5) * 10), 0, sourceImage.Width - 1);
            int newY = Clamp((int)(y + (rand.NextDouble() - 0.5) * 10), 0, sourceImage.Height - 1);
            return sourceImage.GetPixel(newX, newY);
        }
    }
}
