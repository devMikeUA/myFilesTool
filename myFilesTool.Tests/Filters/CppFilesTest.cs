using System.Collections.Generic;
using System.IO;
using myFilesTool.Interfaces;
using myFilesTool.Tools;
using NSubstitute;
using Xunit;

namespace myFilesTool.Tests.Filters
{
    public class CppFilesTest
    {
        [Fact]
        public async void Get_Test()
        {
            IDirectory iDirectory = Substitute.For<IDirectory>();
            iDirectory.GetFilesAsync("*.cpp", SearchOption.AllDirectories).Returns(new List<string>
            {
                @"f\bla\ra\t.dat",
                @"books\csharp\csharp.pdf",
                @"proj\tools\utils.cpp"
            });

            int expected1 = 1;
            string expected2 = @"proj\tools\utils.cpp";

            IFileFilter filter = new FilterManager("cpp");
            string[] actual = await filter.GetFilteredFiles(iDirectory);

            Assert.Equal(expected1, actual.Length);
            Assert.Equal(expected2, actual[0]);
        }
    }
}