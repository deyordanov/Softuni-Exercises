namespace EDriveRent
{
    using EDriveRent.Core;
    using EDriveRent.Core.Contracts;
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
