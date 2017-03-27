using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace myFilesTool.Interfaces
{
    public interface IDirectory
    {
        string StartDirectory { get; }

        Task<List<string>> GetFilesAsync(string searchPattern, SearchOption searchOption);
    }
}