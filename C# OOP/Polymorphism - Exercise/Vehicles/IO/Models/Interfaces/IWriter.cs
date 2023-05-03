using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.IO
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);    
    }
}
