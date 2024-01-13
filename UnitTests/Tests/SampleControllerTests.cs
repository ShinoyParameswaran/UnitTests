using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTests.Controllers;
using UnitTests.Model;
using UnitTests.Services;
using Xunit;

namespace UnitTests.Tests
{

    public class SampleControllerTests
    {
        [Fact]
        public void GetById_ReturnsOkResult_WhenSpecialSampleExists()
        {
            // Arrange
            int sampleId = 1;
            var sampleServiceMock = new Mock<ISampleService>();
            sampleServiceMock.Setup(service => service.ProcessSampleData(sampleId))
                            .Returns(new SampleResult { Message = "Special sample processed", Success = true });
            var controller = new SampleController(sampleServiceMock.Object);

            // Act
            var result = controller.GetById(sampleId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.Equal("Special sample processed", (result.Value as SampleResult).Message);
        }

        [Fact]
        public void GetById_ReturnsOkResult_WhenQuantityGreaterThan10()
        {
            // Arrange
            int sampleId = 2;
            var sampleServiceMock = new Mock<ISampleService>();
            sampleServiceMock.Setup(service => service.ProcessSampleData(sampleId))
                            .Returns(new SampleResult { Message = "Sample processed with quantity greater than 10", Success = true });
            var controller = new SampleController(sampleServiceMock.Object);

            // Act
            var result = controller.GetById(sampleId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.Equal("Sample processed with quantity greater than 10", (result.Value as SampleResult).Message);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenSampleNotFound()
        {
            // Arrange
            int sampleId = 3;
            var sampleServiceMock = new Mock<ISampleService>();
            sampleServiceMock.Setup(service => service.ProcessSampleData(sampleId))
                            .Returns(new SampleResult { Message = "Sample not found", Success = false });
            var controller = new SampleController(sampleServiceMock.Object);

            // Act
            var result = controller.GetById(sampleId) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.Equal("Sample not found", (result.Value as SampleResult).Message);
        }
    }
}
