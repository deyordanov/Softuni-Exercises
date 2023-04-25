using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public interface IPet
    {
        string Name { get; }
        string Birthdate { get; }
    }
}
