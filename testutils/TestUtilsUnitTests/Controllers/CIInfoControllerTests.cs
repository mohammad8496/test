using Moq;
using System;
using System.Threading.Tasks;
using TestUtils.Controllers;
using TestUtils.Models;
using Xunit;

namespace TestUtilsUnitTests.Controllers
{
    public class CIInfoControllerTests
    {
        [Fact]
        public async void TestBuildDate()
        {
            // Arrange
            var buildDateString = "2017-12-18 18:12:20 +0430";
            var mock = new Mock<ICIInfoProvider>();
            mock.Setup(repo => repo.GetBuildDateAsStringAsync()).Returns(Task.FromResult(buildDateString));
            var controller = new CIInfoController(mock.Object);

            // Act
            var result = await controller.BuildDate();

            // Assert
            Assert.Equal(buildDateString, result);
        }
    }
}
