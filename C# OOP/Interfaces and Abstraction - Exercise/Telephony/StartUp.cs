using System.Threading.Channels;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            foreach (string phoneNumber in phoneNumbers)
            {
                if(phoneNumber.Length == 10)
                {
                    Console.WriteLine(smartphone.Call(phoneNumber));
                }
                else if(phoneNumber.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(phoneNumber));
                }
            }
            Array.ForEach(sites, x => Console.WriteLine(smartphone.Browse(x)));
        }
    }
}