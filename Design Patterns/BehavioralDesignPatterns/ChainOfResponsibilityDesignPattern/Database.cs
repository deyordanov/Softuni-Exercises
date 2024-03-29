namespace ChainOfResponsibilityDesignPattern;

public class Database
{
    private readonly Dictionary<string, string> _users;

    public Database()
    {
        this._users = new Dictionary<string, string>();
        this._users.Add("user1", "user1");
        this._users.Add("user2", "user2");
        this._users.Add("admin1", "admin1");
    }

    public bool IsValidUser(string username)
        => this
            ._users
            .ContainsKey(username);

    public bool IsValidPassword(string username, string password)
        => this
            ._users
            .First(user => user.Key == username)
            .Value == password;
}