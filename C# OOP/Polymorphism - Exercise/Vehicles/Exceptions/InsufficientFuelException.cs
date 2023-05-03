using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Exceptions
{
    internal class InsufficientFuelException : Exception
    {
        public InsufficientFuelException(string message)
            :base(message)
        {
            
        }
    }
}
