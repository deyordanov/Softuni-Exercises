namespace BankLoan.Models;

public class BranchBank : Bank
{
    private const int capacity = 25;
    public BranchBank(string name) : base(name, capacity)
    {
    }
}