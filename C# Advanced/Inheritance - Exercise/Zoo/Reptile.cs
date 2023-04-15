using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class Reptile : Animal
    {
        protected Reptile(string name) : base(name)
        {
        }
    }
}
