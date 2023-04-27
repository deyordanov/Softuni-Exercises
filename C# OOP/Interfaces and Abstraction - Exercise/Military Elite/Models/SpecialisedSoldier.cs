using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}Corps: {Corps}";
        }
    }
}
