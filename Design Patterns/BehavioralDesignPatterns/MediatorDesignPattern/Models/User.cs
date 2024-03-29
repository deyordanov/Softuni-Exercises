namespace MediatorDesignPattern.Models;

using Mediators.Contracts;

public class User
{
    private IChatRoomMediator _chatRoomMediator;

    public User(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public void SetChatRoom(IChatRoomMediator chatRoomMediator)
        => this._chatRoomMediator = chatRoomMediator;

    public void SendMessage(string message)
        => this._chatRoomMediator.SendMessage(message, this);

    public void ReceiveMessage(string message)
        => Console.WriteLine($"Message received({this.Name}): {message}");
}