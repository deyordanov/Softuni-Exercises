namespace ChainOfResponsibilityDesignPattern;

using Handlers;

public class AuthService
{
    private readonly Handler _handler;

    public AuthService(Handler handler)
    {
        this._handler = handler;
    }

    public bool LogIn(string username, string password)
    {
        if (this._handler.Handle(username, password))
        {
            Console.WriteLine("Authorization has been successful!");
            return true;
        }

        return false;
    }
}