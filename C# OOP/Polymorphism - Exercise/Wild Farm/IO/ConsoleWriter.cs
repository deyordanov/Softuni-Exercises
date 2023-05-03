using WildFarm.IO.Interfaces;

namespace WildFarm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object text) => Console.Write(text.ToString());

        public void WriteLine(object text) => Console.WriteLine(text.ToString());
    }
}
