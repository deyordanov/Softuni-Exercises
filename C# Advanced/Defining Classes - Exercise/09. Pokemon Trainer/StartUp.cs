using _09._Pokemon_Trainer;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string tournament;
            while((tournament = Console.ReadLine()) != "Tournament")
            {
                string[] input = tournament.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Trainer trainer = trainers.Any(t => t.Name == input[0]) ? trainers.Where(t => t.Name == input[0]).First() : new Trainer(input[0]);
                Pokemon pokemon = new Pokemon(input[1], input[2], int.Parse(input[3]));
                trainer.Pokemons.Add(pokemon);
                if(!trainers.Any(t => t.Name == input[0]))
                {
                    trainers.Add(trainer);
                }
            }

            string end;
            while((end = Console.ReadLine()) != "End")
            {
                string element = end;
                foreach(Trainer trainer in trainers)
                {
                    if(trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }


            Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(t => t.Badges).Select(t => $"{t.Name} {t.Badges} {t.Pokemons.Count()}")));
        }
    }
}