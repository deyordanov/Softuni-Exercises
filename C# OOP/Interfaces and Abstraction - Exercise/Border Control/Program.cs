using BorderControl.Models;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> ids = new List<string>();
            string end;
            while((end = Console.ReadLine()) != "End")
            {
                string[] input = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(input.Length == 3)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    ids.Add(citizen.Id);
                }
                else
                {
                    Robot robot = new Robot(input[0], input[1]);
                    ids.Add(robot.Id);  
                }
            }
            string fakeIdNumber = Console.ReadLine();
            ids = ids.Where(x => x.Substring(x.Length - fakeIdNumber.Length) == fakeIdNumber).ToList();
            ids.ForEach(x => Console.WriteLine(x));
        }
    }
}