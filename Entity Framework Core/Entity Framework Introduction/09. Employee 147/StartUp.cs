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
        Console.WriteLine(GetEmployee147(dbContext));
    }

    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employee = context
            .Employees
            .Find(147);

        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
        sb.AppendLine(string.Join(Environment.NewLine, employee!
            .EmployeesProjects
            .OrderBy(p => p.Project.Name)
            .Select(p => p.Project.Name)));

        return sb.ToString().TrimEnd();
    }
}