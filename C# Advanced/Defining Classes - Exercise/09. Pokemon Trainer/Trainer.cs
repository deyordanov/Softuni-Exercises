using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }    

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
