namespace Demo.Data.Models.Resolvers;

using AutoMapper;

public class FullNameResolver : IValueResolver<Employee, EmployeeDto, string>
{
    //This class is used to basically map the FirstName and LastName properties of the
    //Employee class to the FullName property of the EmployeeDto
    public string Resolve(Employee source, EmployeeDto destination, string destMember, ResolutionContext context)
        => $"{source.FirstName} {source.LastName}";
}