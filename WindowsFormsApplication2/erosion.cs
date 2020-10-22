using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class erosion: MorfologeFilter
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color min = Color.FromArgb(255, 255, 255);

            for (int j = -MH / 2; j <= MH / 2; j++)
                for (int i = -MW / 2; i <= MW / 2; i++)
                {
                    Color pixel = sourceImage.GetPixel(x + i, y + j);

                    if (mask[i + MW / 2, j + MH / 2] != 0 && pixel.R < min.R && pixel.G < min.G && pixel.B < min.B)
                        min = pixel;
                }

            return min;
        }
    }
}
