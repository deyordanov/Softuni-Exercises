namespace BankLoan.Repositories;

using System.Collections.Generic;
using System.Linq;
using Contracts;
using Models.Contracts;

public class LoanRepository : IRepository<ILoan>
{
    private List<ILoan> loans;

    public LoanRepository()
    {
        this.loans = new List<ILoan>();
    }
    public IReadOnlyCollection<ILoan> Models => this.loans.AsReadOnly();
    public void AddModel(ILoan model)
        => this.loans.Add(model);

    public bool RemoveModel(ILoan model)
        => this.loans.Remove(model);
    public ILoan FirstModel(string name)
        => this.loans.Where(loan => loan.GetType().Name == name).FirstOrDefault();
}