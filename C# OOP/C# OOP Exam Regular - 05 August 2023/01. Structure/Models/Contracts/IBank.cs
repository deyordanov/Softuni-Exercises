using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Models.Contracts
{
    public interface IBank
    {
        public string Name { get; }
        public int Capacity { get; }
        public IReadOnlyCollection<ILoan> Loans { get; }
        public IReadOnlyCollection<IClient> Clients { get; }

        public double SumRates();

        public void AddClient(IClient Client);
        public void RemoveClient(IClient Client);
        public void AddLoan(ILoan loan);
        public string GetStatistics();
    }
}
