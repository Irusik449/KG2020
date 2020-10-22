using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class IncreaseBrightness : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            float R = sourceColor.R;
            float G = sourceColor.G;
            float B = sourceColor.B;
            R = R + 20;
            G = G + 20;
            B = B + 20;
            return Color.FromArgb(Clamp((int)R, 0, 255), Clamp((int)G, 0, 255), Clamp((int)B, 0, 255)
        );
        }
    }
}
