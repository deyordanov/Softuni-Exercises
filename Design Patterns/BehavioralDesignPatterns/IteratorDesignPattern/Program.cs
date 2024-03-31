using IteratorDesignPattern.Iterators;
using IteratorDesignPattern.Iterators.Contracts;
using IteratorDesignPattern.Iterators.Enums;
using IteratorDesignPattern.Models;

NavigationApp navApp = new NavigationApp();
navApp.AddRoute(new Route("Mountain Pass", 120, 9, 2));
navApp.AddRoute(new Route("Coastal Way", 150, 8, 5));
navApp.AddRoute(new Route("Highway", 100, 3, 8));

// Iterate by shortest route
IIterator shortestIterator = navApp.CreateIterator(IteratorType.Shortest);
while (shortestIterator.HasNext())
{
    Route route = shortestIterator.Next();
    Console.WriteLine($"Shortest: {route.Name}");
}

// Iterate by scenic value
IIterator scenicIterator = navApp.CreateIterator(IteratorType.Scenic);
while (scenicIterator.HasNext())
{
    Route route = scenicIterator.Next();
    Console.WriteLine($"Scenic: {route.Name}");
}

// Iterate by least traffic
IIterator leastTrafficIterator = navApp.CreateIterator(IteratorType.LeastTraffic);
while (leastTrafficIterator.HasNext())
{
    Route route = leastTrafficIterator.Next();
    Console.WriteLine($"Least Traffic: {route.Name}");
}