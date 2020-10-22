using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApplication2
{
    class MedianFilter : MatrixFilter
    {
        int Sort(int n, int[] mass)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (mass[j] > mass[j + 1])
                    {
                        int temp;
                        temp = mass[j];
                        mass[j] = mass[j + 1];
                        mass[j + 1] = temp;
                    }
                }
            }
            return (mass[n / 2 + 1]);
        }

        public Bitmap create_new_bitmap(int radius, Bitmap image)
        {
            int[] massR = new Int32[radius * radius];
            int[] massG = new Int32[radius * radius];
            int[] massB = new Int32[radius * radius];
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            int resultR = 0;
            int resultG = 0;
            int resultB = 0;
            int kkk = image.Height;
            for (int x = radius / 2 + 1; x < image.Height - radius / 2 - 2; x++)
                for (int y = (radius / 2 + 1); y < image.Width - radius / 2 - 2; y++)
                {
                    int k = 0;
                    for (int i = y - radius / 2; i < y + radius / 2 + 1; i++)
                    {
                        for (int j = x - radius / 2; j < x + radius / 2 + 1; j++)
                        {
                            Color sourceColor = image.GetPixel(i, j);
                            massR[k] = (Int32)(sourceColor.R);
                            massG[k] = (Int32)(sourceColor.G);
                            massB[k] = (Int32)(sourceColor.B);
                            k++;
                        }
                    }
                    resultR = Sort(radius * radius, massR);
                    resultG = Sort(radius * radius, massG);
                    resultB = Sort(radius * radius, massB);
                    Color resultColor = Color.FromArgb(
                    Clamp(resultR, 0, 255),
                    Clamp(resultG, 0, 255),
                    Clamp(resultB, 0, 255)
                    );
                    resultImage.SetPixel(y, x, resultColor);
                }
            return resultImage;
        }
    }
}
