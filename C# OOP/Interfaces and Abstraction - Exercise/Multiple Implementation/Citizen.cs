using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.id = id;
            this.birthdate = birthdate;

        }
        public string Name 
        {
            get => this.name;
            set => this.name = value;
        }


        public int Age
        {
            get => this.age;
            set => this.age = value;
        }
        public string Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string Birthdate
        {
            get => this.birthdate;
            set => this.birthdate = value;
        }
    }
}
