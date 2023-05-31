namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> fileExtensions = new SortedDictionary<string, List<FileInfo>>();
            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                if (!fileExtensions.ContainsKey(info.Extension))
                {
                    fileExtensions.Add(info.Extension, new List<FileInfo>());
                }

                fileExtensions[info.Extension].Add(info);
            }   

            StringBuilder sb = new StringBuilder();
            foreach(var pair in fileExtensions)
            {
                sb.AppendLine(pair.Key);
                foreach(FileInfo file in pair.Value)
                {
                    sb.AppendLine($"--{file.Name} - {file.Length / 1024.0 :F3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
