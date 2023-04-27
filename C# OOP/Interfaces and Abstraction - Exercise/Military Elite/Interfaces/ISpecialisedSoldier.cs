using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
