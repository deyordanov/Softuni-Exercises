using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAdd
    {
        private List<string> elements;

        public AddCollection()
        {
            this.elements = new List<string>();
        }
        public List<string> Elements => this.elements;

        public int Add(string element)
        {
            elements.Add(element);
            return elements.Count() - 1;
        }
    }
}
