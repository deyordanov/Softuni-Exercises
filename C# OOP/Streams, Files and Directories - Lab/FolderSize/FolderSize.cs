namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            double sum = 0;
            foreach(FileInfo file in directory.GetFiles())
            {
                sum += file.Length;
            }

            foreach(DirectoryInfo dir in directory.GetDirectories())
            {
                foreach(FileInfo file in dir.GetFiles())
                {
                    sum += file.Length;
                }
            }

            double sumInKb = sum / 1024;

            File.WriteAllText(outputFilePath, $"{sumInKb} KB");
        }
    }
}
