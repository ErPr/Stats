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
            // GetCurrentDirectory() - gets the current working directory of the appplication
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            var files = directory.GetFiles("*.txt");

            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }

            // keeps console open until enter is pressed
            Console.ReadLine();
        }
    }
}
