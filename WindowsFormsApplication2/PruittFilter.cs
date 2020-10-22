using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class PruittFilterX : MatrixFilter
    {
        public PruittFilterX()
        {
            kernel = new float[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
        }
    }
    class PruittFilterY : MatrixFilter
    {
        public PruittFilterY()
        {
            kernel = new float[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
        }
    }
    class PruittFilter : MatrixFilter
    {
        Filters FilterX;
        Filters FilterY;
        public PruittFilter()
        {
            FilterX = new PruittFilterX();
            FilterY = new PruittFilterY();
        }
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color dX = FilterX.calculateNewPixelColor(sourceImage, x, y);
            Color dY = FilterY.calculateNewPixelColor(sourceImage, x, y);
            float resultR = (float)Math.Sqrt(dX.R * dX.R + dY.R * dY.R);
            float resultG = (float)Math.Sqrt(dX.G * dX.G + dY.G * dY.G);
            float resultB = (float)Math.Sqrt(dX.B * dX.B + dY.B * dY.B);

            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));
        }
    }
}
