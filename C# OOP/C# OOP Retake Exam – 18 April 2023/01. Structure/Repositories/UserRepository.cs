namespace EDriveRent.Repositories;

using System.Collections.Generic;
using System.Linq;
using Contracts;
using Models.Contracts;

public class UserRepository : IRepository<IUser>
{
    private List<IUser> users;

    public UserRepository()
    {
        this.users = new List<IUser>();
    }
    public void AddModel(IUser model)
        => this.users.Add(model);

    public bool RemoveById(string identifier)
        => this.users.Remove(this.users.FirstOrDefault(user => user.DrivingLicenseNumber == identifier));

    public IUser FindById(string identifier)
        => this.users.FirstOrDefault(user => user.DrivingLicenseNumber == identifier);

    public IReadOnlyCollection<IUser> GetAll()
        => this.users.AsReadOnly();
}