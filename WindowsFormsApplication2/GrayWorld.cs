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
    class GrayWorld
    {
        /*
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float Rs = 0;
            float Gs = 0;
            float Bs = 0;
            int N = sourceImage.Width * sourceImage.Height;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor1 = sourceImage.GetPixel(i, j);
                    Rs = Rs + sourceColor1.R;
                    Gs = Gs + sourceColor1.G;
                    Bs = Bs + sourceColor1.B;

                }
            }

            
            int R1 = (int)Rs / N;
            int G1 = (int)Gs / N;
            int B1 = (int)Bs / N;
            int Avg = (R1 + G1 + B1) / 3;
            Color sourceColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb(Clamp((int)sourceColor.R * Avg / R1, 0, 255), Clamp((int)sourceColor.G * Avg / G1, 0, 255), Clamp((int)sourceColor.B * Avg / B1, 0, 255));

        }
        */

        public int Clamp(int value, int min, int max) //чтобы привести значения к допустимому диапозону
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
                    Red += (Int32)sourcecolor.R;
                    Green += (Int32)sourcecolor.G;
                    Blue += (Int32)sourcecolor.B;

                }
            }
            double avRed = 0.0;
            double avGreen = 0.0;
            double avBlue = 0.0;
            double N = sourceImage.Width * sourceImage.Height;
            avRed = Red / N;
            avGreen = Green / N;
            avBlue = Blue / N;
            double avg = (avRed + avGreen + avBlue) / 3;
            Bitmap resultIm = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);//получаем цвет исходного пикселя
                    Color resultColor = Color.FromArgb(Clamp((Int32)(sourceColor.R * avg / avRed), 0, 255), Clamp((Int32)(sourceColor.G * avg / avGreen), 0, 255), Clamp((Int32)(sourceColor.B * avg / avBlue), 0, 255));

                    resultIm.SetPixel(i, j, resultColor);

                }
            }
            return resultIm;

        }
    }
}
    