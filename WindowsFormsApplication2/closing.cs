using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class closing: MorfologeFilter
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap dilation = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = MW / 2; i < dilation.Width - MW / 2; i++)
            {
                worker.ReportProgress((int)((float)i / dilation.Width * 50));
                if (worker.CancellationPending)
                    return null;

                for (int j = MH / 2; j < dilation.Height - MH / 2; j++)
                    dilation.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
            }

            Bitmap result = new Bitmap(dilation);

            for (int i = MW / 2; i < result.Width - MW / 2; i++)
            {
                worker.ReportProgress((int)((float)i / result.Width * 50 + 50));
                if (worker.CancellationPending)
                    return null;

                for (int j = MH / 2; j < result.Height - MH / 2; j++)
                    result.SetPixel(i, j, CalculateErosion(dilation, i, j));
            }

            return result;
        }

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

        private Color CalculateErosion(Bitmap sourceImage, int x, int y)
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
