using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using myFilesTool.Interfaces;

namespace myFilesTool.Tools
{
    public class FileManager : IDirectory
    {
        public string StartDirectory { get; }

        public FileManager(string startDirectory)
        {
            StartDirectory = startDirectory;
        }

        public Task<List<string>> GetFilesAsync(string searchPattern, SearchOption searchOption)
        {
            List<string> fileList = new List<string>();

            return Task.Factory.StartNew(() =>
            {
                foreach (string file in Directory.GetFiles(StartDirectory, searchPattern, SearchOption.AllDirectories))
                {
                    fileList.Add(file.Substring(StartDirectory.Length));
                }

                return fileList;
            });
        }
    }
}
