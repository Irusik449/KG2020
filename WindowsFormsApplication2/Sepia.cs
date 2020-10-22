using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class Sepia : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 20;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            float R = Intensity + 2 * k;
            float G = Intensity + 0.5f * k;
            float B = Intensity - 1 * k;
            return Color.FromArgb(
            Clamp((int)R, 0, 255),
            Clamp((int)G, 0, 255),
            Clamp((int)B, 0, 255)
        );
        }
        
    }
}
