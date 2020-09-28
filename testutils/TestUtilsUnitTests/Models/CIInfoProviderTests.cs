using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestUtils.Models;
using TestUtils.Utils;
using Xunit;

namespace TestUtilsUnitTests.Models
{
    public class CIInfoProviderTests
    {
        private Dictionary<string, string> CIInfoForTest
        {
            get
            {
                return new Dictionary<string, string>
                {
                    ["branch"] = "master",
                    ["build_date"] = "2017-11-18 17:12:20 +0430",
                    ["version"] = "12"
                };
            }
        }

        private readonly string ciInfoFilePath = "ci_info";

        [Fact]
        public async void TestGetCIInfo()
        {
            // Arrange
            CIInfoProvider ciInfoProvider = GetCIInfoProviderForTest();

            // Act
            var result = await ciInfoProvider.GetCIInfoAsync();

            // Assert
            Assert.Equal(CIInfoForTest, result);
        }

        [Fact]
        public async void TestGetBuildDateAsString()
        {
            // Arrange
            CIInfoProvider ciInfoProvider = GetCIInfoProviderForTest();

            // Act
            var result = await ciInfoProvider.GetBuildDateAsStringAsync();

            // Assert
            Assert.Equal(CIInfoForTest["build_date"], result);
        }

        private CIInfoProvider GetCIInfoProviderForTest()
        {
            var ciInfoProviderMock = GetFileProviderMock();
            var options = Options.Create(new AppOptions
            {
                CIInfoFilePath = ciInfoFilePath
            });
            var logger = new Mock<ILogger<CIInfoProvider>>();
            var ciInfoProvider = new CIInfoProvider(ciInfoProviderMock.Object, options, logger.Object);
            return ciInfoProvider;
        }

        private Mock<IFileProvider> GetFileProviderMock()
        {
            var CIInfoString = JsonConvert.SerializeObject(CIInfoForTest);
            var fileProviderMock = new Mock<IFileProvider>();
            var fileInfoMock = new Mock<IFileInfo>();

            byte[] byteArray = Encoding.ASCII.GetBytes(CIInfoString);
            var stream = new MemoryStream(byteArray);

            fileInfoMock.Setup(f => f.CreateReadStream()).Returns(stream);
            fileProviderMock.Setup(p => p.GetFileInfo(ciInfoFilePath)).Returns(fileInfoMock.Object);

            return fileProviderMock;
        }
    }
}
