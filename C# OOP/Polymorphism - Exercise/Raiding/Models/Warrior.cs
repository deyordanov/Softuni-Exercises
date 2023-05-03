
namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int power = 100;
        public Warrior(string name) : base(name, power)
        {
        }
    }
}
