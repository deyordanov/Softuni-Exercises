using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IRemove
    {
        private List<string> elements;

        public AddRemoveCollection()
        {
            elements = new List<string>();
        }
        public List<string> Elements => this.elements;

        public int Add(string element)
        {
            elements.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            int a = 0;
            string elementToRemove = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return elementToRemove;
        }
    }
}
