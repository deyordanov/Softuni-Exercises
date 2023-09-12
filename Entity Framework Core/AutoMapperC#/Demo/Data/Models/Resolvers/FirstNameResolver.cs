namespace Demo.Data.Models.Resolvers;

using AutoMapper;

public class FirstNameResolver : IValueResolver<EmployeeDto, Employee, string>
{
    public string Resolve(EmployeeDto source, Employee destination, string destMember, ResolutionContext context)
        => source.FullName.Split(" ", StringSplitOptions.None)[0];
}