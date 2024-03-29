using ChainOfResponsibilityDesignPattern;
using ChainOfResponsibilityDesignPattern.Handlers;

Database database = new Database();
Handler handler = new UserExistsHandler(database);
    handler
        .SetNextHandler(new ValidPasswordHandler(database))
        .SetNextHandler(new RoleCheckHandler());
AuthService authService = new AuthService(handler);

Console.WriteLine("<==============================>");
authService.LogIn("username", "password");
Console.WriteLine("<==============================>");
authService.LogIn("user1", "user1");
Console.WriteLine("<==============================>");
authService.LogIn("user1", "user2");
Console.WriteLine("<==============================>");
authService.LogIn("admin1", "admin1");
Console.WriteLine("<==============================>");