using System.Collections.Generic;
using System.IO;
using myFilesTool.Interfaces;
using myFilesTool.Tools;
using NSubstitute;
using Xunit;

namespace myFilesTool.Tests.Filters
{
    public class AllFilesTest
    {
        [Fact]
        public async void Get_Test()
        {
            IDirectory iDirectory = Substitute.For<IDirectory>();
            iDirectory.GetFilesAsync("*.*", SearchOption.AllDirectories).Returns(new List<string>
            {
                @"f\bla\ra\t.dat",
                @"books\csharp\csharp.pdf"
            });

            int expected1 = 2;
            string expected2 = @"f\bla\ra\t.dat";
            string expected3 = @"books\csharp\csharp.pdf";

            IFileFilter filter = new FilterManager("all");
            string[] actual = await filter.GetFilteredFiles(iDirectory);

            Assert.Equal(expected1, actual.Length);
            Assert.Equal(expected2, actual[0]);
            Assert.Equal(expected3, actual[1]);
        }
    }
}
