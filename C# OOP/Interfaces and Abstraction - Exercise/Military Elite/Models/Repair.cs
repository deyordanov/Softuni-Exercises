using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
