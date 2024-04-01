using FacadeDesignPattern.Facades;

NotificationFacade notificationFacade = new NotificationFacade();

notificationFacade.SendNotification(
    "user@example.com", 
    "Hello", 
    "This is a test notification across all channels.");