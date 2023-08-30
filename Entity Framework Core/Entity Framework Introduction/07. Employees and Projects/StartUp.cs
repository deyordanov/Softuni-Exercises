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
        Console.WriteLine(GetEmployeesInPeriod(dbContext));
    }

    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context
            .Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(p => p.Project.StartDate.Year >= 2001 && 
                                             p.Project.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        Name = p.Project.Name, 
                        StartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture), 
                        EndDate = p.Project.EndDate.HasValue ?
                            p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) :
                            "not finished"
                    }).ToArray()      
            }).Take(10).ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}