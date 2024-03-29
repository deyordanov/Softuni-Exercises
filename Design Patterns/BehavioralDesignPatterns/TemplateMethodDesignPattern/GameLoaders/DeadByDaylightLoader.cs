namespace TemplateMethodDesignPattern.GameLoaders;

public class DeadByDaylightLoader : BaseGameLoader
{
    public override byte[] LoadData()
    {
        Console.WriteLine("Loading Dead By Daylight data...");
        return new byte[0];
    }

    public override void CreateObjects()
    {
        Console.WriteLine("Creating Dead By Daylight objects...");
    }

    public override void LoadAdditionalFiles()
    {
        Console.WriteLine("Loading additional Dead By Daylight files...");
    }

    public override void InitializeProfiles()
    {
        Console.WriteLine("Initializing Dead By Daylight profiles...");
    }
}