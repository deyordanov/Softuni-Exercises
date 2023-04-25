using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models
{
    public interface ICall
    {
        public string Call(string number);
    }
}
