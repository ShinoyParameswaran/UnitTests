using UnitTests.Model;
using UnitTests.Repository;
using UnitTests.Services;
using Moq;
using Xunit;

namespace UnitTests.Tests
{

    public class SampleServiceTests
    {
        [Fact]
        public void ProcessSampleData_ReturnsSpecialSampleResult_WhenSampleIsSpecial()
        {
            // Arrange
            int sampleId = 1;
            var sampleRepositoryMock = new Mock<ISampleRepository>();
            sampleRepositoryMock.Setup(repo => repo.GetSampleById(sampleId))
                                .Returns(new Sample { Id = sampleId, IsSpecial = true });

            var sampleService = new SampleService(sampleRepositoryMock.Object);

            // Act
            var result = sampleService.ProcessSampleData(sampleId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("Special sample processed", result.Message);
        }

        [Fact]
        public void ProcessSampleData_ReturnsDefaultSampleResult_WhenSampleIsNotSpecialAndQuantityIsNotGreaterThan10()
        {
            // Arrange
            int sampleId = 2;
            var sampleRepositoryMock = new Mock<ISampleRepository>();
            sampleRepositoryMock.Setup(repo => repo.GetSampleById(sampleId))
                                .Returns(new Sample { Id = sampleId, IsSpecial = false, Quantity = 5 });

            var sampleService = new SampleService(sampleRepositoryMock.Object);

            // Act
            var result = sampleService.ProcessSampleData(sampleId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("Default sample processing", result.Message);
        }

        [Fact]
        public void ProcessSampleData_ReturnsQuantityGreaterThan10Result_WhenQuantityIsGreaterThan10()
        {
            // Arrange
            int sampleId = 3;
            var sampleRepositoryMock = new Mock<ISampleRepository>();
            sampleRepositoryMock.Setup(repo => repo.GetSampleById(sampleId))
                                .Returns(new Sample { Id = sampleId, IsSpecial = false, Quantity = 15 });

            var sampleService = new SampleService(sampleRepositoryMock.Object);

            // Act
            var result = sampleService.ProcessSampleData(sampleId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("Sample processed with quantity greater than 10", result.Message);
        }

        [Fact]
        public void ProcessSampleData_ReturnsNotFoundResult_WhenSampleNotFound()
        {
            // Arrange
            int sampleId = 4;
            var sampleRepositoryMock = new Mock<ISampleRepository>();
            sampleRepositoryMock.Setup(repo => repo.GetSampleById(sampleId))
                                .Returns((Sample)null);

            var sampleService = new SampleService(sampleRepositoryMock.Object);

            // Act
            var result = sampleService.ProcessSampleData(sampleId);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal("Sample not found", result.Message);
        }
    }
}
