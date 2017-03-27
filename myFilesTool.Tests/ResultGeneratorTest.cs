using System.Collections.Generic;
using System.IO;
using myFilesTool.Filters;
using myFilesTool.Interfaces;
using NSubstitute;
using Xunit;

namespace myFilesTool.Tests
{
    public class ResultGeneratorTest
    {
        [Fact]
        public async void Generete_Test()
        {
            List<string> expectedData = new List<string>
            {
                @"f\bla\ra\t.dat",
                @"books\csharp\csharp.pdf",
                @"proj\tools\utils.cpp",
                @"proj\timer\main.cpp"
            };

            int expectedLength = 4;

            IDirectory iDirectory = Substitute.For<IDirectory>();
            iDirectory.GetFilesAsync("", SearchOption.AllDirectories).Returns(expectedData);

            IFileFilter iFileFilter = Substitute.For<IFileFilter>();
            iFileFilter.GetFilteredFiles(iDirectory).Returns(expectedData.ToArray());


            ResultGenerator resultGenerator = new ResultGenerator(iDirectory, iFileFilter);
            IStreamWriter actual = await resultGenerator.Generate();


            Assert.Equal(expectedLength, actual.Data.Length);
            Assert.Equal(expectedData.ToArray(), actual.Data);
        }
    }
}
