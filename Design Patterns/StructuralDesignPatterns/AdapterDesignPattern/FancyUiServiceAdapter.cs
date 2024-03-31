namespace AdapterDesignPattern;

using Data;
using Models;
using Models.Contracts;

public class FancyUiServiceAdapter : IMultiRestoApp
{
    private readonly FancyUiService _fancyUiService;

    public FancyUiServiceAdapter()
    {
        this._fancyUiService = new FancyUiService();
    }

    public void DisplayMenus(XmlData data)
    {
        JsonData jsonData = this.ConvertXmlToJson(data);
        this._fancyUiService.DisplayMenus(jsonData);
    }

    public void DisplayRecommendations(XmlData data)
    {
        JsonData jsonData = this.ConvertXmlToJson(data);
        this._fancyUiService.DisplayRecommendations(jsonData);
    }

    private JsonData ConvertXmlToJson(XmlData data)
    {
        Console.WriteLine("Converting XML to JSON...");
        return new JsonData();
    }
}