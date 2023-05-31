using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateeModifier
{
    public class DateModifier
    {
        public int CalculateDays(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            return Math.Abs((int)(first - second).TotalDays);
        }
    }
}
