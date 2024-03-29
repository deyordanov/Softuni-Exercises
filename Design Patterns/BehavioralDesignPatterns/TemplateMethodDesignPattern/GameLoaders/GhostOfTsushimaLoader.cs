namespace TemplateMethodDesignPattern.GameLoaders;

public class GhostOfTsushimaLoader : BaseGameLoader
{
    public override byte[] LoadData()
    {
        Console.WriteLine("Loading Ghost Of Tsushima data...");
        return new byte[0];
    }

    public override void CreateObjects()
    {
        Console.WriteLine("Creating Ghost Of Tsushima objects...");
    }

    public override void LoadAdditionalFiles()
    {
        Console.WriteLine("Loading additional Ghost Of Tsushima files...");
    }

    public override void InitializeProfiles()
    {
        Console.WriteLine("Initializing Ghost Of Tsushima profiles...");
    }
}