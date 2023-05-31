using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        private int age;
        private string name;

        public Person()
        {
            this.Age = 1;
            this.Name = "No name";
        }

        public Person(int age)
            : this()
        {
            this.Age = age;
        }

        public Person(int age, string name)
            :this(age)
        {
            this.Name = name;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

    }
}
