using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shape
{
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double thickness = 0.4;
            double areIn = this.radius - 0.4;
            double areOut = this.radius + 0.4;
            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < areOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= Math.Pow(areIn, 2) && value <= Math.Pow((areOut), 2))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
