using BankLoan.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.IO
{
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
