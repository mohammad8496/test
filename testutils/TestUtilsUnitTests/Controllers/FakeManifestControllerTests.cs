using Microsoft.AspNetCore.Mvc;
using System;
using TestUtils.Controllers;
using TestUtils.Models.Manifest;
using TestUtils.Utils;
using Xunit;

namespace TestUtilsUnitTests.Controllers
{
    public class FakeManifestControllerTests
    {
        [Fact]
        public void TestGenerateHappy()
        {
            // Arrange
            var controller = new FakeManifestController();

            // Act
            var result = controller.Generate(FakeManifest);

            // Assert
            var viewResult = Assert.IsType<String>(result);
            Assert.Equal(FakeManifest.ToString(), result);

        }

        [Fact]
        public async void TestDownload()
        {
            // Arrange
            var controller = new FakeManifestController();

            // Act
            var result = controller.Download(FakeManifest);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal($"{FakeManifest.Name}.zip", fileResult.FileDownloadName);
            Assert.Equal("application/zip", fileResult.ContentType);
            var zipFile = fileResult.FileContents;
            var zipContents = await ZipUtils.GetInsideAZipContentsAsync(zipFile);
            Assert.Single(zipContents);

            var keysEnumerator = zipContents.Keys.GetEnumerator();
            keysEnumerator.MoveNext();
            var firstKey = keysEnumerator.Current;
            Assert.Equal(FakeManifest.Name, firstKey);
            Assert.Equal(FakeManifest.ToString(), zipContents[firstKey]);
        }

        [Fact]
        public void TestGenerateAndDownload()
        {
            // Arrange
            var controller = new FakeManifestController();

            // Act
            var result = controller.GenerateAndDownload(FakeManifest);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(FakeManifest.ToString(), viewResult.Model.ToString());
            Assert.Null(viewResult.ViewName);
        }

        private static FakeManifest FakeManifest
        {
            get
            {
                return new FakeManifest()
                {
                    Name = "manifest1",
                    Owner = "Hamed",
                    NumberOfBills = 2,
                };
            }
        }
    }
}
