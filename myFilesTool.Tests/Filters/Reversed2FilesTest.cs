using System.Collections.Generic;
using System.IO;
using myFilesTool.Interfaces;
using myFilesTool.Tools;
using NSubstitute;
using Xunit;

namespace myFilesTool.Tests.Filters
{
    public class Reversed2FilesTest
    {
        [Fact]
        public async void Get_Test()
        {
            IDirectory iDirectory = Substitute.For<IDirectory>();
            iDirectory.GetFilesAsync("*.*", SearchOption.AllDirectories).Returns(new List<string>
            {
                @"f\bla\ra\t.dat",
                @"books\csharp\csharp.pdf",
                @"proj\tools\utils.cpp"
            });

            int expected1 = 3;
            string expected2 = @"tad.t\ar\alb\f";
            string expected3 = @"fdp.prahsc\prahsc\skoob";
            string expected4 = @"ppc.slitu\sloot\jorp";

            IFileFilter filter = new FilterManager("reversed2");
            string[] actual = await filter.GetFilteredFiles(iDirectory);

            Assert.Equal(expected1, actual.Length);
            Assert.Equal(expected2, actual[0]);
            Assert.Equal(expected3, actual[1]);
            Assert.Equal(expected4, actual[2]);
        }
    }
}
