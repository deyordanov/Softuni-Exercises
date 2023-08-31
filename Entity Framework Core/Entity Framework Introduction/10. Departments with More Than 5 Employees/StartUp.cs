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
        Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dbContext));
    }

    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var departments = context
            .Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees.Select(e => new
                {
                    EmployeeFistName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    EmployeeJobTitle = e.JobTitle,
                })
                    .OrderBy(e => e.EmployeeFistName)
                    .ThenBy(e => e.EmployeeLastName)
                    .ToArray()
            }).ToArray();

        foreach (var department in departments)
        {
            sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");
            foreach (var employee in department.Employees)
            {
                sb.AppendLine($"{employee.EmployeeFistName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}