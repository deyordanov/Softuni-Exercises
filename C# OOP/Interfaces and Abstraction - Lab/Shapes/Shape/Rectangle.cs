using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shape
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void Draw()
        {
            Console.WriteLine(new string('*', width));
            for (int col = 1; col < height - 1; col++)
            {
                for (int row = 0; row < width; row++)
                {
                    if (row == 0 || row == width - 1)
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
            Console.WriteLine(new string('*', width));
        }
    }
}
