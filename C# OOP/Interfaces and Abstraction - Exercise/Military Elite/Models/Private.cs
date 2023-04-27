using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MilitaryElite.Models
{
    public class Private : Solider, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:F2}";
        }
    }
}
