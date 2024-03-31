using AdapterDesignPattern.Data;
using AdapterDesignPattern.Models.Contracts;
using AdapterDesignPattern.Models;
using AdapterDesignPattern;

XmlData myData = new XmlData();

// Old UI
IMultiRestoApp multiRestoApp = new MultiRestoApp();
multiRestoApp.DisplayMenus(myData);
multiRestoApp.DisplayRecommendations(myData);

Console.WriteLine("<========================>");

// New UI
IMultiRestoApp adapter = new FancyUiServiceAdapter();
adapter.DisplayMenus(myData);
adapter.DisplayRecommendations(myData);