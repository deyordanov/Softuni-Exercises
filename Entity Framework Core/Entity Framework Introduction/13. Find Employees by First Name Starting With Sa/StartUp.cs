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
        Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(dbContext));
    }

    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context
            .Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName);

        return string.Join(Environment.NewLine,
            employees.Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));
    }
}