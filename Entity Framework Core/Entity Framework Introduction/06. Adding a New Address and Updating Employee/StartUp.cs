using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        Console.WriteLine(AddNewAddressToEmployee(dbContext));
    }

    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        context
                .Employees
                .First(e => e.LastName == "Nakov")
                .Address = new Address { AddressText = "Vitoshka 15", TownId = 4 };
        context.SaveChanges();
        var addresses = context
            .Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText);

        return string.Join(Environment.NewLine, addresses);
    }
}