namespace FacadeDesignPattern.Facades;

using ThirdPartyLibrary;

public class NotificationFacade
{
    private readonly EmailNotificationClient _emailNotificationClient;
    private readonly SmsNotificationClient _smsNotificationClient;
    private readonly PushNotificationClient _pushNotificationClient;

    public NotificationFacade()
    {
        this._emailNotificationClient = new EmailNotificationClient();
        this._smsNotificationClient = new SmsNotificationClient();
        this._pushNotificationClient = new PushNotificationClient();
    }

    public void SendNotification(
        string receiver,
        string subject,
        string message)
    {
        this._emailNotificationClient.SendEmail(receiver, subject, message);
        this._smsNotificationClient.SendSms(receiver, message);
        this._pushNotificationClient.SendPushNotification(receiver, message);
    }
}