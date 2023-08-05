namespace BankLoan.Models;

public class Student : Client
{
    private const int interest = 2;
    public Student(string name, string id,  double income) : base(name, id, interest, income)
    {
    }

    public override void IncreaseInterest()
        => this.Interest += 1;
}