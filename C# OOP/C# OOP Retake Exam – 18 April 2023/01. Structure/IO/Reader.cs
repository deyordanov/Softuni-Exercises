namespace EDriveRent.IO
{
    using EDriveRent.IO.Contracts;
    using System;
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
