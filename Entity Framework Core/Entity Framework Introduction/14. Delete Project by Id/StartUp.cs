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
        Console.WriteLine(DeleteProjectById(dbContext));
    }

    public static string DeleteProjectById(SoftUniContext context)
    {
        var projectsToDelete = context
            .EmployeesProjects
            .Where(p => p.Project.ProjectId == 2);

        context.EmployeesProjects.RemoveRange(projectsToDelete);

        var projectToDelete = context.Projects.Find(2);

        context.Projects.Remove(projectToDelete!);

        context.SaveChanges();

        return string.Join(Environment.NewLine, context.Projects.Take(10).Select(p => p.Name));
    }
}