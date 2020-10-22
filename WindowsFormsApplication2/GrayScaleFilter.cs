using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class GrayScaleFilter : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int) (0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            Color resultColor = Color.FromArgb(Intensity, Intensity, Intensity);
            return resultColor;
        }
    }
}
