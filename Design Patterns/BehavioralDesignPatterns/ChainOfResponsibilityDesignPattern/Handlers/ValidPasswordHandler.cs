namespace ChainOfResponsibilityDesignPattern.Handlers;

public class ValidPasswordHandler : Handler
{
    private readonly Database _database;
    public ValidPasswordHandler(
        Database database) 
        : base()
    {
        this._database = database;
    }

    public override bool Handle(string username, string password)
    {
        if (!this._database.IsValidPassword(username, password))
        {
            Console.WriteLine("Incorrect password!");
            Console.WriteLine("Please try again.");
            return false;
        }

        return this.HandleNext(username, password);
    }
}