namespace SingletonDesignPattern;

public class Singleton
{
    private static volatile Singleton? _instance;
    private static readonly object Lock = new object();

    public static Singleton Instance(string? value)
    {
        if (_instance == null)
        {
            lock (Lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                    _instance.Value = value;
                }
            }
        }

        return _instance;
    }

    public string? Value { get; set; }
}