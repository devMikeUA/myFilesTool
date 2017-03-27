using System.Threading.Tasks;

namespace myFilesTool.Interfaces
{
    public interface IFileFilter
    {
        string FilterBy { get; set; }

        Task<string[]> GetFilteredFiles(IDirectory iDirectory);
    }
}
