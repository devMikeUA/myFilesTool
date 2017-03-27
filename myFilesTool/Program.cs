using System;
using System.Threading.Tasks;
using myFilesTool.Filters;
using myFilesTool.Interfaces;
using myFilesTool.Tools;

namespace myFilesTool
{
    class Program
    {
        private static string startDirectory;
        private static string resultFile = "results.txt";
        private static string filterBy;

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough arguments.");
                Console.ReadKey();
                return;
            }

            startDirectory = args[0];
            filterBy = args[1];

            if (args.Length >= 3)
                resultFile = args[2];

            GenerateResultToFile().Wait();

            Console.ReadKey();
        }

        private static async Task GenerateResultToFile()
        {
            IDirectory iDirectory = new FileManager(startDirectory);
            IFileFilter iFileFilter = new FilterManager(filterBy);

            ResultGenerator resultGenerator = new ResultGenerator(iDirectory, iFileFilter);
            IStreamWriter sWriter = await resultGenerator.Generate();

            sWriter.WriteToFile(resultFile);
        }
    }
}
