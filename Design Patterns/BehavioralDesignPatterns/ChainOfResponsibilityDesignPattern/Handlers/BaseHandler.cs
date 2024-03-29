namespace ChainOfResponsibilityDesignPattern.Handlers;

public abstract class Handler
{
    private Handler? _next;

    protected Handler() { }

    public abstract bool Handle(string username, string password);

    public Handler SetNextHandler(Handler next)
    {
        this._next = next;
        return next;
    }

    public bool HandleNext(string username, string password)
    {
        if (this._next == null)
        {
            return true;
        }

        return this._next.Handle(username, password);
    }
}