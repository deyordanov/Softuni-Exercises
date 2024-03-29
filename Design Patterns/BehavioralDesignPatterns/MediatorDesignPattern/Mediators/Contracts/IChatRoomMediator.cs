namespace MediatorDesignPattern.Mediators.Contracts;

using Models;

public interface IChatRoomMediator
{
    void SendMessage(string message, User user);
}