using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var fileContents = ReadFile(fileName);
            string[] fileLines = fileContents.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries );

            foreach (var line in fileLines)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }

        public static string ReadFile(string fileName)
        {
            using (var CSVReader = new StreamReader(fileName))
            {
                return CSVReader.ReadToEnd();
            }
        }

        public static List<string> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<string>();
            using (var reader = new StreamReader(fileName))
            {
                while(reader.Peek() > - 1)
                {
                    string line = reader.ReadLine();
                    soccerResults.Add(line);
                }
            }
            return soccerResults;
        }
    }
}