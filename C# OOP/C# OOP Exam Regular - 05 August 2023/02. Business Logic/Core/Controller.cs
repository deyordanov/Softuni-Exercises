namespace BankLoan.Core;

using System;
using System.Linq;
using System.Text;
using Contracts;
using Models;
using Models.Contracts;
using Repositories;
using Repositories.Contracts;
using Utilities.Messages;

public class Controller : IController
{
    private IRepository<ILoan> loans;
    private IRepository<IBank> banks;

    public Controller()
    {
        this.loans = new LoanRepository();
        this.banks = new BankRepository();
    }
    public string AddBank(string bankTypeName, string name)
    {
        if (bankTypeName != nameof(BranchBank) && bankTypeName != nameof(CentralBank))
        {
            throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
        }

        IBank bank = null;
        if (bankTypeName == nameof(BranchBank))
        {
            bank = new BranchBank(name);
        }
        else if (bankTypeName == nameof(CentralBank))
        {
            bank = new CentralBank(name);
        }

        this.banks.AddModel(bank);
        return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
    }

    public string AddLoan(string loanTypeName)
    {
        if (loanTypeName != nameof(MortgageLoan) && loanTypeName != nameof(StudentLoan))
        {
            throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
        }

        ILoan loan = null;
        if (loanTypeName == nameof(MortgageLoan))
        {
            loan = new MortgageLoan();
        }
        else if (loanTypeName == nameof(StudentLoan))
        {
            loan = new StudentLoan();
        }

        this.loans.AddModel(loan);
        return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
    }

    public string ReturnLoan(string bankName, string loanTypeName)
    {
        ILoan loan = this.loans.FirstModel(loanTypeName);
        if (loan == null)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
        }

        IBank bank = this.banks.Models.First(bank => bank.Name == bankName);
        this.loans.RemoveModel(loan);
        bank.AddLoan(loan);

        return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
    }

    public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
    {
        if (clientTypeName != nameof(Adult) && clientTypeName != nameof(Student))
        {
            throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
        }

        IBank bank = this.banks.Models.First(bank => bank.Name == bankName);

        if (clientTypeName == nameof(Student) && bank.GetType().Name == nameof(CentralBank) || clientTypeName == nameof(Adult) && bank.GetType().Name == nameof(BranchBank))
        {
            return OutputMessages.UnsuitableBank;
        }

        IClient client = null;
        if (clientTypeName == nameof(Student))
        {
            client = new Student(clientName, id, income);
        }
        else if (clientTypeName == nameof(Adult))
        {
            client = new Adult(clientName, id, income);
        }

        bank.AddClient(client);
        return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
    }

    public string FinalCalculation(string bankName)
    {
        IBank bank = this.banks.Models.First(bank => bank.Name == bankName);

        double total = bank.Clients.Sum(client => client.Income) + bank.Loans.Sum(loan => loan.Amount);

        return string.Format(OutputMessages.BankFundsCalculated, bankName, $"{total:F2}");
    }

    public string Statistics()
    {
        StringBuilder sb = new StringBuilder();

        foreach (IBank b in this.banks.Models)
        {
            sb.AppendLine(b.GetStatistics());
        }

        return sb.ToString().TrimEnd();
    }
}