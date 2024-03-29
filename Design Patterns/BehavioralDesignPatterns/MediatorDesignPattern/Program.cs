using MediatorDesignPattern.Mediators;
using MediatorDesignPattern.Models;

ChatRoomMediator chatRoomMediator = new ChatRoomMediator();

List<User> users = new List<User>()
{
    new User("user1"),
    new User("user2"),
    new User("user3"),
    new User("user4"),
    new User("user5"),
    new User("user6"),
};

foreach (User user in users)
{
    user.SetChatRoom(chatRoomMediator);
    chatRoomMediator.Register(user);
}

users[0].SendMessage("Hello from user1!");