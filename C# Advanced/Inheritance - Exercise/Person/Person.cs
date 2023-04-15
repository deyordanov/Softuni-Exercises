using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    internal class Person
    {
        private int age;
        private string name;

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public virtual int Age
        {
            get => age;
            protected set
            {
                if(value >= 0)
                {
                    age = value;
                }
            }
        }
        public string Name { get; set; }      

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
