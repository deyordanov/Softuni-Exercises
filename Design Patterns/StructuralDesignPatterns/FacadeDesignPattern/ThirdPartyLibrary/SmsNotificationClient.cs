namespace FacadeDesignPattern.ThirdPartyLibrary;

public class SmsNotificationClient
{
    public void SendSms(string phoneNumber, string message)
    {
        Console.WriteLine($"Sending an SMS to {phoneNumber} - {message}");
    }
}