using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.IO.Models
{
    internal class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
