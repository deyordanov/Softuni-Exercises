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
        Console.WriteLine(GetAddressesByTown(dbContext));
    }

    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var addresses = context
            .Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                Text = a.AddressText,
                TownName = a.Town.Name,
                EmployeeCount = a.Employees.Count
            })
            .ToArray();

        foreach (var address in addresses)
        {
            sb.AppendLine($"{address.Text}, {address.TownName} - {address.EmployeeCount} employees");
        }

        return sb.ToString().TrimEnd();
    }
}