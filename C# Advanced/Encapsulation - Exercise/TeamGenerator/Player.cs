using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGenerator
{
    public class Player
    {
        private int MaxStat = 100;
        private int MinStat = 0;
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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
        public int Endurance 
        {
            get => this.endurance;
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }
                this.endurance = value;
            } 
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }
        public double Skill() => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
    }
}
