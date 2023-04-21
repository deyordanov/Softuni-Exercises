using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGenerator
{
    public class Team
    {
        private readonly List<Player> players;
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }
        public string Rating => players.Count() == 0 ? "0" : $"{players.Average(p => p.Skill()):F0}";
        public void AddPlayer(Player player) => players.Add(player);
        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);
            if(player is null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            players.Remove(player);
        }
    }
}
