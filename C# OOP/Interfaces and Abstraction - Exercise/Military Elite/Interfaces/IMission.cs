using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        string MissionName { get; }
        State State { get; }
        void CompleteMission();
    }
}
