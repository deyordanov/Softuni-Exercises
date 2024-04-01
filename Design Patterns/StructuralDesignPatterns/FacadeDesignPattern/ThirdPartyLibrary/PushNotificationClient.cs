namespace FacadeDesignPattern.ThirdPartyLibrary;

public class PushNotificationClient
{
    public void SendPushNotification(string deviceIdentifier, string message)
    {
        Console.WriteLine($"Send a push notification to {deviceIdentifier} - {message}");
    }
}