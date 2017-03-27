using System;
using System.IO;
using myFilesTool.Interfaces;

namespace myFilesTool.Tools
{
    class StrimWriterTool : IStreamWriter
    {
        public string[] Data { get; }

        public StrimWriterTool(string[] data)
        {
            Data = data;
        }

        public async void WriteToFile(string resultFile)
        {
            if (Data == null)
            {
                Console.WriteLine("There is nothing to write down!");
                return;
            }

            using (StreamWriter streamWriter = new StreamWriter(resultFile))
            {
                foreach (string file in Data)
                {
                    await streamWriter.WriteLineAsync(file);
                }

                streamWriter.Flush();

                Console.WriteLine("Writing to file is complete.");
            }
        }
    }
}
