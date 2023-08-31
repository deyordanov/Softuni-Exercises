using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        Console.WriteLine(GetEmployeesWithSalaryOver50000(dbContext));
    }

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(x => x.Salary > 50000)
            .OrderBy(x => x.FirstName)
            .ToList();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }
}