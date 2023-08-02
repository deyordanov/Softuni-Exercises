namespace EDriveRent.Repositories;

using System.Collections.Generic;
using System.Linq;
using Contracts;
using Models.Contracts;

public class RouteRepository : IRepository<IRoute>
{
    private List<IRoute> routes;

    public RouteRepository()
    {
        this.routes = new List<IRoute>();
    }

    public void AddModel(IRoute model)
        => this.routes.Add(model);

    public bool RemoveById(string identifier)
        => this.routes.Remove(this.FindById(identifier));

    public IRoute FindById(string identifier)
        => this.routes.FirstOrDefault(route => route.RouteId == int.Parse(identifier));

    public IReadOnlyCollection<IRoute> GetAll()
        => this.routes.AsReadOnly();
}