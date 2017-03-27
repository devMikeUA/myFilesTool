using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using myFilesTool.Interfaces;

namespace myFilesTool.Tools
{
    public class FilterManager : IFileFilter
    {
        public string FilterBy { get; set; }

        private string startDirectory;

        public FilterManager(string filterBy)
        {
            FilterBy = filterBy;
        }

        public async Task<string[]> GetFilteredFiles(IDirectory iDirectory)
        {
            string[] result;
            List<string> files;

            startDirectory = iDirectory.StartDirectory;

            switch (FilterBy)
            {
                case "all":
                    files = await iDirectory.GetFilesAsync("*.*", SearchOption.AllDirectories);
                    result = GetAllFiles(files);
                    break;

                case "cpp":
                    files = await iDirectory.GetFilesAsync("*.cpp", SearchOption.AllDirectories);
                    result = GetCppFiles(files);
                    break;

                case "reversed1":
                    files = await iDirectory.GetFilesAsync("*.*", SearchOption.AllDirectories);
                    result = GetReversed1Files(files);
                    break;

                case "reversed2":
                    files = await iDirectory.GetFilesAsync("*.*", SearchOption.AllDirectories);
                    result = GetReversed2Files(files);
                    break;

                default:
                    Console.WriteLine("Filter is wrong! Needed: 'all', 'cpp', 'reversed1', 'reversed2'.");
                    return null;
            }

            return result;
        }

        private string[] GetAllFiles(List<string> fileList)
        {
            List<string> list = new List<string>();

            foreach (string file in fileList)
            {
                list.Add(file);
            }

            return list.ToArray();
        }

        private string[] GetCppFiles(List<string> fileList)
        {
            List<string> list = new List<string>();

            foreach (string file in fileList)
            {
                if (file.EndsWith(".cpp"))
                    list.Add(file);
            }

            return list.ToArray();
        }

        private string[] GetReversed1Files(List<string> fileList)
        {
            List<string> list = new List<string>();

            foreach (string file in fileList)
            {
                string revertFileName = "";
                string namePart = "";

                foreach (char part in file)
                {
                    if (part == '\\')
                    {
                        revertFileName = revertFileName.Insert(0, $"\\{namePart}");
                        namePart = "";
                    }
                    else
                    {
                        namePart += part;
                    }
                }

                revertFileName = revertFileName.Insert(0, namePart);

                list.Add(revertFileName);
            }

            return list.ToArray();
        }

        private string[] GetReversed2Files(List<string> fileList)
        {
            List<string> list = new List<string>();

            foreach (string file in fileList)
            {
                string revertFileName = "";

                for (int i = file.Length - 1; i >= 0; i--)
                {
                    revertFileName += file[i];
                }

                list.Add(revertFileName);
            }

            return list.ToArray();
        }
    }
}
