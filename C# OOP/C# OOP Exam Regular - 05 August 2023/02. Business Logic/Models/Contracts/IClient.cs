using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Models.Contracts
{
    public interface IClient
    {
        public string Name { get; }
        public string Id { get; }
        public int Interest { get; }
        public double Income { get; }

        public void IncreaseInterest();
    }
}
