using Microsoft.AspNetCore.Mvc;

namespace SimpleChat.Controllers;

using ViewModels;

public class ChatController : Controller
{
    private static List<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();

    public IActionResult Show()
    {
        if (messages.Count < 1)
        {
            return View(new ChatViewModel());
        }

        ChatViewModel chat = new ChatViewModel()
        {
            Messages = messages
                .Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                })
                .ToList()
        };

        return View(chat);
    }

    [HttpPost]
    public IActionResult Send(ChatViewModel chat)
    {
        MessageViewModel newMessage = chat.CurrentMessage;

        messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

        return RedirectToAction("Show");
    }
}