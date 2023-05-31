namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream reader = new FileStream(sourceFilePath, FileMode.Open);
            long lengthOne = (long)Math.Ceiling((double)reader.Length / 2.0);
            long lengthTwo = reader.Length - lengthOne;

            using FileStream writerOne = new FileStream (partOneFilePath, FileMode.Create);
            byte[] bufferOne = new byte[lengthOne];
            reader.Read(bufferOne);
            writerOne.Write(bufferOne);

            using FileStream writerTwo = new FileStream(partTwoFilePath, FileMode.Create);
            byte[] bufferTwo = new byte[lengthTwo];
            reader.Read(bufferTwo);
            writerTwo.Write(bufferTwo);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream writer = new FileStream(joinedFilePath, FileMode.Create);

            using FileStream readerOne = new FileStream(partOneFilePath, FileMode.Open);
            byte[] bufferOne = new byte[readerOne.Length];
            readerOne.Read(bufferOne);
            writer.Write(bufferOne);

            using FileStream readerTwo = new FileStream(partTwoFilePath, FileMode.Open);
            byte[] bufferTwo = new byte[readerTwo.Length];
            readerTwo.Read(bufferTwo);
            writer.Write(bufferTwo);
        }
    }
}