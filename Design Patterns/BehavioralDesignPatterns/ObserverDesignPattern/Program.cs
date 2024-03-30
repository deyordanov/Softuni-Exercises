using ObserverDesignPattern.Listeners;
using ObserverDesignPattern;
using ObserverDesignPattern.Enums;

Store store = new Store();
store.GetNotificationService().Subscribe(Event.NewItem, new EmailMessageListener("denis@gmail.com"));
store.GetNotificationService().Subscribe(Event.Sale, new EmailMessageListener("softuni@gmail.com"));
store.GetNotificationService().Subscribe(Event.Sale, new EmailMessageListener("tusofia@gmail.com"));
store.GetNotificationService().Subscribe(Event.NewItem, new MobileAppListener("DenisIphone"));
store.NewItemPromotion();
Console.WriteLine("<================================>");
store.SalePromotion();
Console.WriteLine("<================================>");
store.GetNotificationService().Unsubscribe(Event.NewItem, new EmailMessageListener("denis@gmail.com"));
store.NewItemPromotion();