using System.Threading.Tasks;
using myFilesTool.Interfaces;
using myFilesTool.Tools;

namespace myFilesTool.Filters
{
    public class ResultGenerator
    {
        private readonly IFileFilter iFileFilter;
        private readonly IDirectory iDirectory;

        public ResultGenerator(IDirectory iDirectory, IFileFilter iFileFilter)
        {
            this.iFileFilter = iFileFilter;
            this.iDirectory = iDirectory;
        }

        public async Task<IStreamWriter> Generate()
        {
            string[] filteredFiles = await iFileFilter.GetFilteredFiles(iDirectory);

            IStreamWriter sWriter = new StrimWriterTool(filteredFiles);

            return sWriter;
        }
    }
}
