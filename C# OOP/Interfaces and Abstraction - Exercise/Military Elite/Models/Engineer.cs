using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, List<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach(IRepair repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
