using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class Animal
    {
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }    
    }
}
