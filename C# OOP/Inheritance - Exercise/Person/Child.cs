using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Person
{
    internal class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {   
        }

        public override int Age
        {
            get => base.Age;
            protected set
            {
                if (value <= 15)
                {
                    base.Age = value;
                }
            }
        }
    }
}
