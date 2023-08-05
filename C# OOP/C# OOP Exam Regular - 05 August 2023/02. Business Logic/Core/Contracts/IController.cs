using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Core.Contracts
{
    public interface IController
    {
        string AddBank(string bankTypeName, string name);
        string AddLoan(string loanTypeName);
        string ReturnLoan(string bankName, string loanTypeName);
        string AddClient(string bankName, string clientTypeName, string clientName, string id, double income);
        string FinalCalculation(string bankName);
        string Statistics();
    }
}
