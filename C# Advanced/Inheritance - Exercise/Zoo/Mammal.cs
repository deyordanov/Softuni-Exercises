using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name) : base(name)
        {
        }
    }
}
