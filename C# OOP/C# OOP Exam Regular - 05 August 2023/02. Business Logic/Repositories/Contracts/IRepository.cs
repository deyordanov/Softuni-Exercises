using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Repositories.Contracts
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> Models { get; }

        public void AddModel(T model);
        public bool RemoveModel(T model);
        public T FirstModel(string name);
    }
}
