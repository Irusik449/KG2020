using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class MotionBlur : MatrixFilter
    {
        public MotionBlur()
        {
            int size = 13;
            kernel = new float[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    if (i != j)
                    { kernel[i, j] = 0; }
                    else { kernel[i, j] = 1.0f/ size; }
            }
        }
        
    }
}
