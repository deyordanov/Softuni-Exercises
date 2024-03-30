namespace ObserverDesignPattern;

using Enums;

public class Store
{
    private readonly NotificationService _notificationService;

    public Store()
    {
        this._notificationService = new NotificationService();
    }

    public void NewItemPromotion()
    {
        this._notificationService.NotifyCustomers(Event.NewItem);
    }

    public void SalePromotion()
    {
        this._notificationService.NotifyCustomers(Event.Sale);
    }

    public NotificationService GetNotificationService()
    {
        return this._notificationService;
    }
}