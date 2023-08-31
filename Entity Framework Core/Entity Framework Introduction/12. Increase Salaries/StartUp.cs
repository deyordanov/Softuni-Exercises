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
        Console.WriteLine(IncreaseSalaries(dbContext));
    }

    public static string IncreaseSalaries(SoftUniContext context)
    {
        string[] departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
        var employees = context
            .Employees
            .Where(e => departments.Contains(e.Department.Name));
        foreach (var employee in employees)
        {
            decimal salary = employee.Salary;
            employee.Salary += salary * 0.12M;
        }

        context.SaveChanges();

        var result = employees
            .Select(e => new { e.FirstName, e.LastName, e.Salary })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        return string.Join(Environment.NewLine, result.Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:F2})"));
    }
}