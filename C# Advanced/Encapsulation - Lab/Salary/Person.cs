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
        private decimal salary;

        public Person(string first, string last, int age, decimal salary)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;
            this.salary = salary;
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

        public decimal Salary
        {
            get => this.salary;
            set => this.salary = value;
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
