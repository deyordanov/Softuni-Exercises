using BankLoan.Core.Contracts;
using BankLoan.IO.Contracts;
using BankLoan.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddBank")
                    {
                        string bankTypeName = input[1];
                        string name = input[2];

                        result = controller.AddBank(bankTypeName, name);
                    }
                    else if (input[0] == "AddLoan")
                    {
                        string loanTypeName = input[1];

                        result = controller.AddLoan(loanTypeName);
                    }
                    else if (input[0] == "ReturnLoan")
                    {
                        string bankName = input[1];
                        string loanTypeName = input[2];

                        result = controller.ReturnLoan(bankName, loanTypeName);
                    }
                    else if (input[0] == "AddClient")
                    {
                        string bankName = input[1];
                        string clientTypeName = input[2];
                        string clientName = input[3];
                        string id = input[4];
                        double income = double.Parse(input[5]);

                        result = controller.AddClient(bankName, clientTypeName, clientName, id, income);
                    }
                    else if (input[0] == "FinalCalculation")
                    {
                        string bankName = input[1];

                        result = controller.FinalCalculation(bankName);
                    }
                    else if (input[0] == "Statistics")
                    {
                        result = controller.Statistics();
                    }
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
