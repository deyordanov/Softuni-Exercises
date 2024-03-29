namespace ChainOfResponsibilityDesignPattern.Handlers;

public class RoleCheckHandler : Handler
{
    public RoleCheckHandler() : base() { }

    public override bool Handle(string username, string password)
    {
        if (username.Contains("admin"))
        {
            Console.WriteLine("Loading admin page...");
            return true;
        }

        Console.WriteLine("Loading user page...");
        return this.HandleNext(username, password);
    }
}