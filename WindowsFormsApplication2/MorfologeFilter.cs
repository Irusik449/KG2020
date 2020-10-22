using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    abstract class MorfologeFilter : Filters
    {
        protected int MW = 3, MH = 3; //размеры структурного множества
        protected int[,] mask = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = MW / 2; i < sourceImage.Width - MW / 2; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;

                for (int j = MH / 2; j < sourceImage.Height - MH / 2; j++)
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
            }

            return resultImage;
        }
    }

}
