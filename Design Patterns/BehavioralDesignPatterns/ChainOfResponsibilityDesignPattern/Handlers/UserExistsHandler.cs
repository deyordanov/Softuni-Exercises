namespace ChainOfResponsibilityDesignPattern.Handlers;

public class UserExistsHandler : Handler
{
    private readonly Database _database;
    public UserExistsHandler(
        Database database) 
        : base()
    {
        this._database = database;
    }

    public override bool Handle(string username, string password)
    {
        if (!this._database.IsValidUser(username))
        {
            Console.WriteLine("A user with this username does not exist!");
            return false;
        }

        return this.HandleNext(username, password);
    }
}