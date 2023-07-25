using System.Security.Principal;

string[] input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
Dictionary<int, decimal> accounts = new Dictionary<int, decimal>();
foreach (string str in input)
{
    string[] account = str.Split('-');
    accounts.Add(int.Parse(account[0]), decimal.Parse(account[1]));
}

string end;
while ((end = Console.ReadLine()) != "End")
{
    try
    {
        string[] commandArgs = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string command = commandArgs[0];
        int accNumber = int.Parse(commandArgs[1]);
        decimal amount = decimal.Parse(commandArgs[2]);

        ValidateInput(command, accNumber, amount);

        if (command == "Deposit")
        {
            accounts[accNumber] += amount;
        }
        else if (command == "Withdraw")
        {
            accounts[accNumber] -= amount;
        }

        Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:F2}");
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(ae.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}

void ValidateInput(string command, int accNumber, decimal amount)
{
    if (command != "Deposit" && command != "Withdraw")
    {
        throw new ArgumentException("Invalid command!");
    }

    if (!accounts.ContainsKey(accNumber))
    {
        throw new ArgumentException("Invalid account!");
    }

    if (command == "Withdraw" && amount > accounts[accNumber])
    {
        throw new ArgumentException("Insufficient balance!");
    }
}