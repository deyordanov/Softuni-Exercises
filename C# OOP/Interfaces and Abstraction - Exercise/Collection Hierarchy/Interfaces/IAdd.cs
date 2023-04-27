using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy.Interfaces
{
    public interface IAdd
    {
        List<string> Elements { get; }
        int Add(string element);
    }
}