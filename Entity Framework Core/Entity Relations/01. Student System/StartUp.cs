using P01_StudentSystem.Data;

public class StartUp
{
    public static void Main(string[] args)
    {
        StudentSystemContext context = new StudentSystemContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}