namespace BankLoan.Repositories;

using System.Collections.Generic;
using System.Linq;
using Contracts;
using Models.Contracts;

public class BankRepository : IRepository<IBank>
{
    private List<IBank> banks;

    public BankRepository()
    {
        this.banks = new List<IBank>();
    }
    public IReadOnlyCollection<IBank> Models => this.banks.AsReadOnly();

    public void AddModel(IBank model)
        => this.banks.Add(model);

    public bool RemoveModel(IBank model)
        => this.banks.Remove(model);

    public IBank FirstModel(string name)
        => this.banks.Where(bank => bank.GetType().Name == name).FirstOrDefault();
}