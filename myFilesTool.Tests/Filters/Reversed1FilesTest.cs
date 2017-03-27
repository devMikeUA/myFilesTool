using System.Collections.Generic;
using System.IO;
using myFilesTool.Interfaces;
using myFilesTool.Tools;
using NSubstitute;
using Xunit;

namespace myFilesTool.Tests.Filters
{
    public class Reversed1FilesTest
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
            string expected2 = @"t.dat\ra\bla\f";
            string expected3 = @"csharp.pdf\csharp\books";

            IFileFilter filter = new FilterManager("reversed1");
            string[] actual = await filter.GetFilteredFiles(iDirectory);

            Assert.Equal(expected1, actual.Length);
            Assert.Equal(expected2, actual[0]);
            Assert.Equal(expected3, actual[1]);
        }
    }
}
