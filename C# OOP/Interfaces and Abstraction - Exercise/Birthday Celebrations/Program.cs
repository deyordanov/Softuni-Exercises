using BorderControl.Models;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> birthdates = new List<string>();
            string end;
            while((end = Console.ReadLine()) != "End")
            {
                string[] input = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    birthdates.Add(citizen.Birthdate);
                }
                else if (input[0] == "Robot")
                {
                    Robot robot = new Robot(input[1], input[2]); 
                }
                else if (input[0] == "Pet")
                {
                    Pet pet = new Pet(input[1], input[2]);
                    birthdates.Add(pet.Birthdate);
                }
            }
            string birthdateYear = Console.ReadLine();
            birthdates = birthdates.Where(x => x.Substring(x.Length - 4) == birthdateYear).ToList();
            birthdates.ForEach(x => Console.WriteLine(x));
        }
    }
}