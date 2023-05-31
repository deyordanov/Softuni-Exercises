namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using StreamReader reader = new StreamReader(bytesFilePath);
            byte[] bytes = File.ReadAllBytes(binaryFilePath);
            List<string> toFind = new List<string>();
            while(!reader.EndOfStream)
            {
                toFind.Add(reader.ReadLine());
            }

            StringBuilder sb = new StringBuilder();
            foreach(byte @byte in bytes)
            {
                if (toFind.Contains(@byte.ToString()))
                {
                    sb.AppendLine(@byte.ToString());
                }
            }
            using StreamWriter writer = new StreamWriter(outputPath);
            writer.WriteLine(sb.ToString().Trim());
        }
    }
}
