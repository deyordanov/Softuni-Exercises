using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string missionName, State state)
        {
            MissionName = missionName;
            State = state;
        }

        public string MissionName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            State = (State)1;
        }

        public override string ToString()
        {
            return $"Code Name: {MissionName} State: {State}";
        }
    }
}
