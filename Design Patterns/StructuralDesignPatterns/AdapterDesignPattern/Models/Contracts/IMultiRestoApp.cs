namespace AdapterDesignPattern.Models.Contracts;

using Data;

public interface IMultiRestoApp
{
    void DisplayMenus(XmlData data);

    void DisplayRecommendations(XmlData data);
}