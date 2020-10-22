using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class EmbossingFilter : MatrixFilter
    {
        public override Color calculateNewPixelColor(Bitmap resultImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, resultImage.Width - 1);
                    int idY = Clamp(y + l, 0, resultImage.Height - 1);
                    Color neighborColor = resultImage.GetPixel(idX, idY);
                    float intensity = 0.299f * neighborColor.R + 0.587f * neighborColor.G + 0.114f * neighborColor.B;
                    resultR += intensity * kernel[k + radiusX, l + radiusY];
                    resultG += intensity * kernel[k + radiusX, l + radiusY];
                    resultB += intensity * kernel[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(Clamp(((int)resultR + 255) / 2, 0, 255), Clamp(((int)resultG + 255) / 2, 0, 255), Clamp(((int)resultB + 255) / 2, 0, 255));
        }
        public EmbossingFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            kernel[0, 0] = 0;
            kernel[0, 1] = 1;
            kernel[0, 2] = 0;
            kernel[1, 0] = 1;
            kernel[1, 1] = 0;
            kernel[1, 2] = -1;
            kernel[2, 0] = 0;
            kernel[2, 1] = -1;
            kernel[2, 2] = 0;

        }

    }
}
