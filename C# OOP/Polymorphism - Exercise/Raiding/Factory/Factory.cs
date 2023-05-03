
namespace Raiding.Factory
{
    using Interfaces;
    using Models.Interfaces;
    using Models;
    using Raiding.Exceptions;

    public class Factory : IFactory
    {
        public IBaseHero CreateHero(string type, string name)
        {
            if(type == "Druid")
            {
                return new Druid(name);
            }
            else if(type == "Paladin")
            {
                return new Paladin(name);
            }
            else if(type == "Rogue")
            {
                return new Rogue(name);
            }
            else if(type == "Warrior")
            {
                return new Warrior(name);
            }
            else
            {
                throw new InvalidHeroTypeException();
            }
        }
    }
}
