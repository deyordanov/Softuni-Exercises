namespace FacadeDesignPattern.ThirdPartyLibrary;

public class EmailNotificationClient
{
    public void SendEmail(string receiver, string subject, string message)
    {
        Console.WriteLine($"Sending an email to {receiver}: {subject} - {message}");
    }
}