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

            // print all filename's in current working directory
            // foreach (var file in files)
            //{
            //    Console.WriteLine(file.Name);
            //}

            var fileName = Path.Combine(directory.FullName, "data.txt");

            var file = new FileInfo(fileName);

            // try-finally 
            //if (file.Exists)
            //{
            //    var reader = new StreamReader(file.FullName);
            //    try
            //    {
            //        Console.SetIn(reader);
            //        Console.WriteLine(Console.ReadLine());
            //    }
            //    finally
            //    {
            //        reader.Close();
            //    }
            //}

            if (file.Exists)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    Console.SetIn(reader);
                    Console.WriteLine(Console.ReadLine());
                }
            }
            // temporarily used to keep console open until user interaction
            Console.ReadKey();
        }
    }
}
