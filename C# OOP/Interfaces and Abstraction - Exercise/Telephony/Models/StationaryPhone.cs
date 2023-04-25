using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models
{
    internal class StationaryPhone : ICall
    {
        public string Call(string number)
        {
            return !number.All(x => char.IsDigit(x)) ? "Invalid number!" : $"Dialing... {number}";
        }
    }
}
