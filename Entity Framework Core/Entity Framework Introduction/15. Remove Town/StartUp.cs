using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        Console.WriteLine(RemoveTown(dbContext));
    }

    public static string RemoveTown(SoftUniContext context)
    {
        var seattleAddresses = context
            .Addresses
            .Where(a => a.Town.Name == "Seattle")
            .ToArray();

        var employeesInSeattle = context
            .Employees
            .ToArray()
            .Where(e => seattleAddresses.Any(a => a.AddressId == e.AddressId))
            .ToArray();

        foreach (Employee employee in employeesInSeattle)
        {
            employee.AddressId = null;
        }

        context.Addresses.RemoveRange(seattleAddresses);

        var seattleTown = context
            .Towns
            .First(t => t.Name == "Seattle");

        context.Towns.Remove(seattleTown);

        context.SaveChanges();

        return $"{seattleAddresses.Length} addresses in Seattle were deleted";
    }
}