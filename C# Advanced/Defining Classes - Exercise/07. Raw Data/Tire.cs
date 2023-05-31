using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Tire
    {
        public Tire(double pressure, int year)
        {
            this.Pressure = pressure;
            this.Year = year;
        }
        public double Pressure { get; set; }

        public double Year { get; set; }
    }
}
