using AutoMapper;
using Demo.Data;
using Demo.Data.Models;
using Demo.Data.Models.Profiles;
using Demo.Data.Models.Resolvers;
using Microsoft.EntityFrameworkCore;

MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<EmployeeProfile>());
IMapper mapper = config.CreateMapper();


DemoContext context = new DemoContext();

Employee employee = context.Employees
    .Include(e => e.Address)
    .Include(e => e.Address.Residents)
    .First();

EmployeeDto dto = mapper.Map<EmployeeDto>(employee);

Employee newEmployee = mapper.Map<Employee>(dto);
;