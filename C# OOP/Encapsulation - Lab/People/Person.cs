using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string first, string last, int age)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;
        }
        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = value;
        }
        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value;
        }
        
        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
