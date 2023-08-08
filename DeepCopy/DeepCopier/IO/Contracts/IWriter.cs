namespace DeepCopy.IO.Contracts;

public interface IWriter
{
    public void Write(string text);
    public void WriteLine(string text);
}