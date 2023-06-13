using ClothesMagazine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Clothes = new List<Cloth>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (this.Clothes.Count() < this.Capacity)
            {
                this.Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            if (this.Clothes.Any(c => c.Color == color))
            {
                this.Clothes = this.Clothes.Where(c => c.Color != color).ToList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Cloth GetSmallestCloth()
        {
            return this.Clothes.OrderBy(c => c.Size).First();
        }

        public Cloth GetCloth(string color)
        {
            return this.Clothes.Where(c => c.Color == color).First();
        }

        public int GetClothCount()
        {
            return this.Clothes.Count();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Type} magazine contains:");
            foreach (Cloth cloth in this.Clothes.OrderBy(c => c.Size))
            {
                sb.AppendLine(cloth.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
