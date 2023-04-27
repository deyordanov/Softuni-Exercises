using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

string end;
while((end = Console.ReadLine()) != "End")
{
    string[] input = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    IPerson citizenOne = new Citizen(input[0], input[1], int.Parse(input[2]));
    IResident citizenTwo = new Citizen(input[0], input[1], int.Parse(input[2]));
    Console.WriteLine(citizenOne.GetName());
    Console.WriteLine(citizenTwo.GetName());
}