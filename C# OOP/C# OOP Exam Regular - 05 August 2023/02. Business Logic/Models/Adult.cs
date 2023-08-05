namespace BankLoan.Models;

public class Adult : Client
{
    private const int interest = 4;
    public Adult(string name, string id, double income) : base(name, id, interest, income)
    {
    }

    public override void IncreaseInterest()
        => this.Interest += 2;
}