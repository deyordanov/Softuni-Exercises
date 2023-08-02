namespace EDriveRent.Repositories.Contracts
{
    using System.Collections.Generic;
    public interface IRepository<T>
    {
        public void AddModel(T model);

        public bool RemoveById(string identifier);

        public T FindById(string identifier);

        public IReadOnlyCollection<T> GetAll();
    }
}
