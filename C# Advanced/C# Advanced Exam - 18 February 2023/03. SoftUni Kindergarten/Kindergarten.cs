using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int cap)
        {
            Name = name;
            Capacity = cap;
            Registry = new List<Child>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public int ChildrenCount => Registry.Count;

        public bool AddChild(Child child)
        {
            if(Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }

        public bool RemoveChild(string fullName)
        {
            if(Registry.Any(c => $"{c.FirstName} {c.LastName}" == fullName))
            {
                Registry = Registry.Where(c => $"{c.FirstName} {c.LastName}" != fullName).ToList();
                return true;
            }
            return false;
        }

        public Child GetChild(string fullName)
        {
            return Registry.Where(c => $"{c.FirstName} {c.LastName}" == fullName).FirstOrDefault();
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            foreach(Child child in Registry.OrderByDescending(c => c.Age).ThenBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
