using BankLoan.Core;
using BankLoan.Core.Contracts;
using System;

namespace BankLoan
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
