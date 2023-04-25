using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        private string name;
        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public IReadOnlyCollection<Person> FirstTeam { get => this.firstTeam.AsReadOnly();  }
        public IReadOnlyCollection<Person> ReserveTeam { get => this.reserveTeam.AsReadOnly(); }
        public string Name { get => this.name; }
        public void AddPlayer(Person person)
        {
            if(person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            return $"First team has {firstTeam.Count()} players.{Environment.NewLine}Reserve team has {reserveTeam.Count()} players.";
        }
    }
}
