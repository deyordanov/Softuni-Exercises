using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy.Models
{
    public class MyList : IUsed
    {
        private List<string> elements;

        public MyList()
        {
            elements = new List<string>();
        }
        public int Count => this.elements.Count();

        public List<string> Elements => this.elements;

        public int Add(string element)
        {
            elements.Insert(0, element);
            return 0;

        }

        public string Remove()
        {
            string elementToRemove = elements[0];
            elements.RemoveAt(0);
            return elementToRemove;
        }
    }
}
