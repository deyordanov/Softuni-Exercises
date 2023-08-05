using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Models.Contracts
{
    public interface ILoan
    {
        public int InterestRate { get; }
        public double Amount { get; }
    }
}
