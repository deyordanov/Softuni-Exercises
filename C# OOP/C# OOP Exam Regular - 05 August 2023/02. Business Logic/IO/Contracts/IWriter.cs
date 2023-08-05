using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.IO.Contracts
{
    public interface IWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}
