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
    class ShiftFilter : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = Clamp(x - 50, 0, sourceImage.Width - 1);
            int newY = Clamp(y, 0, sourceImage.Height - 1);
            return sourceImage.GetPixel(newX, newY);
        }
    }
}
