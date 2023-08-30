using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));
    }

    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employees = context
            .Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToList();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }
}