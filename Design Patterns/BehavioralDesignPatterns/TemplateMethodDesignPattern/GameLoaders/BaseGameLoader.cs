namespace TemplateMethodDesignPattern.GameLoaders;

public abstract class BaseGameLoader
{
    public void Load()
    {
        byte[] data = this.LoadData();
        this.CreateObjects();
        this.LoadAdditionalFiles();
        this.InitializeProfiles();
        this.CleanTemporaryFiles();
    }

    public abstract byte[] LoadData();

    public abstract void CreateObjects();

    public abstract void LoadAdditionalFiles();

    public abstract void InitializeProfiles();

    protected void CleanTemporaryFiles()
    {
        Console.WriteLine("Cleaning temporary files...");
    }
}