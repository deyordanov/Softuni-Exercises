namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            int count = 1;
            
            using (StreamReader one = new StreamReader(firstInputFilePath))
            {
                using(StreamReader two = new StreamReader(secondInputFilePath))
                {
                    using(StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        while (true)
                        {
                            string lineOne = one.ReadLine();
                            string lineTwo = two.ReadLine();
                            if(lineOne == null && lineTwo == null)
                            {
                                break;
                            }
                            if(lineOne != null)
                            {
                                writer.WriteLine(lineOne);
                            }
                            if(lineTwo != null)
                            {
                                writer.WriteLine(lineTwo);
                            }
                        }
                    }
                }
            }
        }
    }
}
