using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string first, string last, int age, decimal salary)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if(value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                this.lastName = value;
            }
        }
        
        public int Age
        {
            get => this.age;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age = value;
            }
        }

        public decimal Salary
        {
            get => this.salary;
            private set
            {
                if(value < 650M)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                this.salary = value;
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
        public void IncreaseSalary(decimal percentage)
        {
            if(this.Age < 30)
            {
                this.salary = this.salary + this.salary * (percentage / 100 )/2;
            }
            else
            {
                this.salary = this.salary + this.salary * (percentage / 100);
            }
        }
    }
}
