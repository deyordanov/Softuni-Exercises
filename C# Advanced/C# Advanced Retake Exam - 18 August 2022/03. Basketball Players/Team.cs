using System;
using System.Collections.Generic;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int pos, char group)
        {
            Name = name;
            OpenPositions = pos;
            Group = group;
            Players = new List<Player>();
        }
        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            if(player.Name )
            if(Count < OpenPositions)
            {
                Players.Add(player);

            }
        }
    }
}
