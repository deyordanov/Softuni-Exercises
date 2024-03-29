namespace MediatorDesignPattern.Mediators;

using Contracts;
using Models;

public class ChatRoomMediator : IChatRoomMediator
{
    private readonly Dictionary<string, User> users;

    public ChatRoomMediator()
    {
        this.users = new Dictionary<string, User>();
    }

    public void Register(User user)
    {
        this.users.TryAdd(user.Name, user);

        user.SetChatRoom(this);
    }

    public void SendMessage(string message, User user)
    {
        if (!this.users.ContainsKey(user.Name))
        {
            return;
        }   

        List<User> participants = this
            .users
            .Where(u => u.Key != user.Name)
            .Select(u => u.Value)
            .ToList();

        foreach (User participant in participants)
        {
            participant.ReceiveMessage(message);
        }
    }
}