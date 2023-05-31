using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power, int dis, string eff)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = dis;
            this.Efficiency = eff;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" {this.Model}:");
            sb.AppendLine($"  Power: {this.Power}");
            sb.AppendLine(this.Displacement == 0 ? "    Displacement: n/a" : $"    Displacement: {this.Displacement}");
            sb.AppendLine(this.Efficiency == null ? "    Efficiency: n/a" : $"    Efficiency: {this.Efficiency}");
            return sb.ToString().TrimEnd();
        }
    }
}
