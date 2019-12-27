namespace MIBI.UnitTests.Controllers
{
    using Moq;
    using Xunit;
    using System;
    using System.Linq;
    using MIBI.Controllers;
    using MIBI.Data.Entities;
    using MIBI.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using MIBI.Models.ViewModels.Sample;
    using MIBI.Models.BindingModels.Sample;
    using System.Threading.Tasks;
    using LoggerAPI.Interfaces;

    public class SampleControllerTest
    {
        [Fact]
        public async Task Get_SampleById_ShouldReturnSample()
        {
            // Arrange
            var sampleId = "12354321-3123-1122-4332-123456789231";

            var sample = new DetailedSampleViewModel()
            {
                Id = new Guid(sampleId),
                Name = "Test 1"
            };

            var serviceMock = new Mock<ISampleService>(); // Using Moq to mock the service
            serviceMock
                .Setup(s => s.GetSampleById(sampleId))
                .ReturnsAsync(sample);

            var loggerMock = new Mock<ILogger>();

            var controller = new SampleController(serviceMock.Object, null, null, loggerMock.Object);

            // Act
            var response = await controller.GetSampleById(sampleId);

            // Assert
            Assert.NotNull(response);
            var okObjectResult = response as OkObjectResult;
            Assert.NotNull(okObjectResult);
            var model = okObjectResult.Value as DetailedSampleViewModel;
            Assert.NotNull(model);
            var modelId = model.Id;
            Assert.Equal(new Guid(sampleId), modelId);
        }

        [Fact]
        public void Get_GetListOfSamples_ShouldReturnListOfSamples()
        {
            // Arrange
            var searchParams = new SearchParametersBindingModel()
            {
                BacteriaName = "Test 1",
                Tags = new string[] { "Test 1" },
                Groups = new string[] { "Test 1" },
                NutrientAgarPlates = new string[] { "Test 1" }
            };

            List<SampleViewModel> listOfsamples = new List<SampleViewModel>()
            {
                new SampleViewModel()
                {
                    Id = new Guid(),
                    Name = "Test 1",
                    Description = "Test Description",
                    Images = null,
                    CreatedOn = DateTime.Now
                },
                new SampleViewModel()
                {
                    Id = new Guid(),
                    Name = "Test 2",
                    Description = "Test Description",
                    Images = null,
                    CreatedOn = DateTime.Now
                }
            };

            var serviceMock = new Mock<ISampleService>();
            serviceMock
                .Setup(s => s.GetAllSamplesByGivenSearchParams(searchParams))
                .Returns(listOfsamples);

            var loggerMock = new Mock<ILogger>();

            var controller = new SampleController(serviceMock.Object, null, null, loggerMock.Object);

            // Act
            var response = controller.GetListOfSamples(searchParams);

            // Assert
            Assert.NotNull(response);
            var okObjectResult = response as OkObjectResult;
            Assert.NotNull(okObjectResult);
            var models = okObjectResult.Value as List<SampleViewModel>;
            Assert.NotNull(models);
            Assert.Equal(2, models.Count());
        }
    }
}
