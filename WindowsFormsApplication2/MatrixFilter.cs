using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class MatrixFilter :Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
            public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
            {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusY; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(
            Clamp((int)resultR, 0, 255),
            Clamp((int)resultG, 0, 255),
            Clamp((int)resultB, 0, 255)
        );
        }
    }
    class gist : MatrixFilter
    {
        public Color f(Color a, int min, int max)
        {
            double r = a.R;
            double g = a.G;
            double b = a.B;
            double res = ((r + g + b) / 3 - min) * (255 / (max - min));
            double rr = r / ((r + g + b) / 3);
            double gg = g / ((r + g + b) / 3);
            double bb = b / ((r + g + b) / 3);
            r = Clamp((int)(res * rr), 0, 255);
            g = Clamp((int)(res * bb), 0, 255);
            b = Clamp((int)(res * bb), 0, 255);
            return Color.FromArgb((int)r, (int)g, (int)b);
        }
        public Bitmap processimage(Bitmap sourceImage)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            int min = 255;
            int max = 0;
            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    int t = (sourceImage.GetPixel(x, y).R + sourceImage.GetPixel(x, y).G + sourceImage.GetPixel(x, y).B) / 3;
                    if (t < min) min = t;
                    if (t > max) max = t;
                }
            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    result.SetPixel(x, y, f(sourceImage.GetPixel(x, y), min, max));
                }
            return result;
        }
    }
}
