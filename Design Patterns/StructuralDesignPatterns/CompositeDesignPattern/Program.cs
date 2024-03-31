using CompositeDesignPattern;
using CompositeDesignPattern.Contracts;
using CompositeDesignPattern.Products;

DeliveryService deliveryService = new DeliveryService();

List<IBox> items1 = new List<IBox>();
items1.Add(new VideoGame("1", 100));

List<IBox> items2 = new List<IBox>();
items2.Add(new Book("2", 200));
items2.Add(new Book("3", 300));
items2.Add((new VideoGame("4", 400)));
items2.Add((new VideoGame("5", 500)));

deliveryService.SetupOrder(items2);
Console.WriteLine(deliveryService.CalculateOrderPrice());