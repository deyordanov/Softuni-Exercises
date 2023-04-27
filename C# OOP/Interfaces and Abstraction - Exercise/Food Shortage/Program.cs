using BorderControl.Models;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Xml;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            List<Rebel> rebels = new List<Rebel>();
            List<Citizen> citizens = new List<Citizen>();
            for(int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(info.Length == 3)
                {
                    Rebel rebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
                    if (!names.Contains(rebel.Name))
                    {
                        names.Add(rebel.Name);
                        rebels.Add(rebel);
                    }
                }
                else if(info.Length == 4)
                {
                    Citizen citizen = new Citizen(info[0], int.Parse(info[1]), info[2], info[3]);
                    if (!names.Contains(citizen.Name))
                    {
                        names.Add(citizen.Name);
                        citizens.Add(citizen);
                    }
                }
            }
            string end;
            while((end = Console.ReadLine()) != "End")
            {
                string name = end;
                if (names.Contains(name))
                {
                    Rebel rebel = rebels.FirstOrDefault(x => x.Name == name);
                    Citizen citizen = citizens.FirstOrDefault(x => x.Name == name);
                    if(rebel is null)
                    {
                        citizen.BuyFood();
                    }
                    else
                    {
                        rebel.BuyFood();
                    }
                }
            }
            Console.WriteLine(citizens.Sum(x => x.Food) + rebels.Sum(x => x.Food));
        }
    }
}