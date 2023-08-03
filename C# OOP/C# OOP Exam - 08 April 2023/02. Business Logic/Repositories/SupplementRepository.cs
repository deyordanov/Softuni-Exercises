namespace RobotService.Repositories;

using System.Collections.Generic;
using System.Linq;
using Contracts;
using Models.Contracts;

public class SupplementRepository : IRepository<ISupplement>
{
    private List<ISupplement> supplements;

    public SupplementRepository()
    {
        this.supplements = new List<ISupplement>();
    }

    public IReadOnlyCollection<ISupplement> Models()
        => this.supplements.AsReadOnly();

    public void AddNew(ISupplement model)
        => this.supplements.Add(model);

    public bool RemoveByName(string typeName)
    {
        ISupplement toRemove = this.supplements.FirstOrDefault(s => s.GetType().Name == typeName);

        return this.supplements.Remove(toRemove);
    }

    public ISupplement FindByStandard(int interfaceStandard)
        => this.supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
}