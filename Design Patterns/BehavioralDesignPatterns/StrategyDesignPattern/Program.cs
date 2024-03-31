using StrategyDesignPattern.Models;
using StrategyDesignPattern.Strategies;

var navApp = new NavigationApp();

// User chooses the shortest route
navApp.SetRoutingStrategy(new ShortestRouteStrategy());
navApp.Navigate("Home", "Office");

// User switches to the least traffic route
navApp.SetRoutingStrategy(new LeastTrafficStrategy());
navApp.Navigate("Home", "Office");

// User wants to enjoy the ride and chooses the scenic route
navApp.SetRoutingStrategy(new ScenicRouteStrategy());
navApp.Navigate("Home", "Office");