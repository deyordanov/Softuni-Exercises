using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Exceptions
{
    public class InvalidFuelAmountException : Exception
    {
        private const string DefaultMessage = "Fuel must be a positive number";

        public InvalidFuelAmountException() 
            : base(DefaultMessage) { }
        public InvalidFuelAmountException(string message) 
            : base(message) { }
    }
}
