using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class dilation : MorfologeFilter
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color max = Color.FromArgb(0, 0, 0);

            for (int j = -MH / 2; j <= MH / 2; j++)
                for (int i = -MW / 2; i <= MW / 2; i++)
                {
                    Color pixel = sourceImage.GetPixel(x + i, y + j);

                    if (mask[i + MW / 2, j + MH / 2] == 1 && pixel.R > max.R && pixel.G > max.G && pixel.B > max.B)
                        max = pixel;
                }

            return max;
        }
    }
}
