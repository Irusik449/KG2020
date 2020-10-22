using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
namespace WindowsFormsApplication2
{
    class PerfectReflector
    {
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;

        }
        public Bitmap processImage(Bitmap sourceImage)
        {
            int Red = 0;
            int Green = 0;
            int Blue = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourcecolor = sourceImage.GetPixel(i, j);
                    if (Red < (Int32)sourcecolor.R)
                        Red = (Int32)sourcecolor.R;
                    if (Green < (Int32)sourcecolor.G)
                        Green = (Int32)sourcecolor.G;
                    if (Blue < (Int32)sourcecolor.B)
                        Blue = (Int32)sourcecolor.B;

                }
            }

            Bitmap resultIm = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);//получаем цвет исходного пикселя
                    Color resultColor = Color.FromArgb(Clamp((Int32)(sourceColor.R * 255 / Red), 0, 255), Clamp((Int32)(sourceColor.G * 255 / Green), 0, 255), Clamp((Int32)(sourceColor.B * 255 / Blue), 0, 255));

                    resultIm.SetPixel(i, j, resultColor);

                }
            }
            return resultIm;

        }
    }
}
