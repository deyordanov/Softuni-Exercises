namespace Raiding.Core
{
    using Interfaces;
    using IO;
    using Factory.Interfaces;
    using Models.Interfaces;
    using Raiding.Exceptions;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private IFactory factory;

        private ICollection<IBaseHero> heroes;

        private Engine()
        {
            this.heroes = new HashSet<IBaseHero>();
        }
        public Engine(IReader reader, IWriter writer, IFactory factory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = factory;
        }
        public void Run()
        {
            int n = int.Parse(this.reader.ReadLine());
            while(heroes.Count < n)
            {
                string heroName = this.reader.ReadLine();
                string heroType = this.reader.ReadLine();
                try
                {
                    IBaseHero currentHero = factory.CreateHero(heroType, heroName);
                    heroes.Add(currentHero);
                }
                catch (InvalidHeroTypeException ihte)
                {
                    this.writer.WriteLine(ihte.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            int bossPower = int.Parse(this.reader.ReadLine());
            foreach (IBaseHero hero in heroes)
            {
                this.writer.WriteLine(hero.CastAbility());
            }
            this.writer.WriteLine(heroes.Sum(h => h.Power) >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
