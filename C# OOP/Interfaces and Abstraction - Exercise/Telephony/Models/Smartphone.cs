using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models
{
    public class Smartphone : ICall, IBrowse
    {
        public string Browse(string site)
        {
            return site.Any(x => char.IsDigit(x)) ? "Invalid URL!" : $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            return !number.All(x => char.IsDigit(x)) ? "Invalid number!" : $"Calling... {number}";
        }
    }
}
