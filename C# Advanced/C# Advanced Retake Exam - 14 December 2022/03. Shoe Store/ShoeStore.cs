using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int cap)
        {
            Name = name;
            StorageCapacity = cap;
            Shoes = new List<Shoe>();
        }
        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }
        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if(Count < StorageCapacity)
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            return "No more space in the storage room.";
        }

        public int RemoveShoes(string material)
        {
            int count = Shoes.Where(s => s.Material == material).Count();
            Shoes = Shoes.Where(s => s.Material != material).ToList();
            return count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.Where(s => s.Type.ToLower() == type.ToLower()).ToList();
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.Where(s => s.Size == size).First();
        }

        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            if(Shoes.Any(s => s.Size == size && s.Type == type))
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (Shoe shoe in Shoes.Where(s => s.Size == size && s.Type == type))
                {
                    sb.AppendLine(shoe.ToString());
                }
            }
            else
            {
                sb.AppendLine("No matches found!");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
