using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.IO.Models
{
    internal class ConsoleWriter : IWriter
    {
        public void Write(string text) => Console.Write(text);

        public void WriteLine(string text) => Console.WriteLine(text);
    }
}
