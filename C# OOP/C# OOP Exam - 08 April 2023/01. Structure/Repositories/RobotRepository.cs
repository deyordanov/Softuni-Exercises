namespace RobotService.Repositories;

using System.Collections.Generic;
using System.Linq;
using Contracts;
using Models.Contracts;

public class RobotRepository : IRepository<IRobot>
{ 
    private List<IRobot> robots;
    public RobotRepository()
    {
        this.robots = new List<IRobot>();
    }
    public IReadOnlyCollection<IRobot> Models()
        => this.robots.AsReadOnly();

    public void AddNew(IRobot model)
        => this.robots.Add(model);

    public bool RemoveByName(string typeName)
    {
        IRobot toRemove = this.robots.FirstOrDefault(r => r.GetType().Name == typeName);
        return this.robots.Remove(toRemove);
    }

    public IRobot FindByStandard(int interfaceStandard)
        => this.robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));
}