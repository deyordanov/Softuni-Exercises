using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Exceptions
{
    public class NotSupportedVehicleTypeException : Exception
    {
        public const string DefaultMessage = "Vehcile type not supported!";
        public NotSupportedVehicleTypeException()
            :base(DefaultMessage) { }

        public NotSupportedVehicleTypeException(string message)
            : base(message) { }
    }
}
