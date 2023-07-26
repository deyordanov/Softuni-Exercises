namespace Stealer.Contracts
{
    public interface ISpy
    {
        string StealFieldInfo(string nameOfClass, string[] fieldsToInvestigate);
        string AnalyzeAccessModifiers(string nameOfClass);
    }
}
