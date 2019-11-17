namespace MIBI.UnitTests.Controllers
{
    using Moq;
    using System;
    using Xunit;
    using MIBI.Controllers;
    using MIBI.Data.Entities;
    using MIBI.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class SampleControllerTest
    {
        [Fact]
        public void Get_SampleById_ShouldReturnSample()
        {
            // Arrange
            var sample = new Sample()
            {
                Id = new Guid("12354321-3123-1122-4332-123456789231"),
                Name = "Test 1"
            };

            var serviceMock = new Mock<ISampleService>(); // Using Moq to mock the service
            serviceMock
                .Setup(s => s.GetSampleById("12354321-3123-1122-4332-123456789231"))
                .Returns(sample);

            var controller = new SampleController(serviceMock.Object, null);

            // Act
            var response = controller.Get("12354321-3123-1122-4332-123456789231");

            // Assert
            Assert.NotNull(response);

            var okObjectResult = response as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as Sample;
            Assert.NotNull(model);

            var sampleId = model.Id;
            Assert.Equal(new Guid("12354321-3123-1122-4332-123456789231"), sampleId);
        }
    }
}
