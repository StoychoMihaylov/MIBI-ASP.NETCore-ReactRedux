namespace MIBI.UnitTests.Controllers
{
    using Xunit;
    using System;
    using MIBI.Models.ViewModels.AutocompleateSuggestions;
    using MIBI.Services.Interfaces;
    using Moq;
    using System.Collections.Generic;
    using MIBI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using MIBI.Data.Entities;

    public class AutocompleteControllerTest
    {
        [Fact]
        public void Get_RetrieveAllNamesOfSamples_ShouldReturnNamesAndStatusCode200()
        {
            // Arrange
            var listOfBacteriaNamesVm = new List<AutocompleteBacteriaNamesViewModel>() {
                new AutocompleteBacteriaNamesViewModel()
                {
                    Id = new Guid(),
                    Name = "Test Sample 1"
                },
                new AutocompleteBacteriaNamesViewModel()
                {
                    Id = new Guid(),
                    Name = "Test Sample 1"
                },
                new AutocompleteBacteriaNamesViewModel()
                {
                    Id = new Guid(),
                    Name = "Test Sample 1"
                },
            };

            var serviceMock = new Mock<IAutocompleteService>(); // Using Moq to mock the service
            serviceMock
                .Setup(s => s.GetAllNamesOfSamples())
                .Returns(listOfBacteriaNamesVm);

            var controller = new AutocompleteController(serviceMock.Object);

            // Act
            var response = controller.GetSampleNames();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Get_RetrieveAllGroups_ShouldReturnNamesAndStatusCode200()
        {
            // Arrange
            var groupsVm = new List<GroupViewModel>() {
                new GroupViewModel()
                {
                    Id = new Guid(),
                    Name = "Test GroupViewModel 1"
                },
                new GroupViewModel()
                {
                    Id = new Guid(),
                    Name = "Test GroupViewModel 1"
                },
                new GroupViewModel()
                {
                    Id = new Guid(),
                    Name = "Test GroupViewModel 1"
                },
            };

            var serviceMock = new Mock<IAutocompleteService>(); // Using Moq to mock the service
            serviceMock
                .Setup(s => s.GetAllGroups())
                .Returns(groupsVm);

            var controller = new AutocompleteController(serviceMock.Object);

            // Act
            var response = controller.GetGroups();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Get_RetrieveAllNutrientAgarPlates_ShouldReturnNamesAndStatusCode200()
        {
            // Arrange
            var nutrientAgarPlatesVm = new List<NutrientAgarPlateViewModel>() {
                new NutrientAgarPlateViewModel()
                {
                    Id = new Guid(),
                    Name = "Test nutrientAgarPlate 1"
                },
                new NutrientAgarPlateViewModel()
                {
                    Id = new Guid(),
                    Name = "Test nutrientAgarPlate 1"
                },
                new NutrientAgarPlateViewModel()
                {
                    Id = new Guid(),
                    Name = "Test nutrientAgarPlate 1"
                },
            };

            var serviceMock = new Mock<IAutocompleteService>(); // Using Moq to mock the service
            serviceMock
                .Setup(s => s.GetAllNutrientAgarPlates())
                .Returns(nutrientAgarPlatesVm);

            var controller = new AutocompleteController(serviceMock.Object);

            // Act
            var response = controller.GetNutrientAgarPlates();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Get_RetrieveAllTags_ShouldReturnNamesAndStatusCode200()
        {
            // Arrange
            var tagNamesVm = new List<Tag>() {
                new Tag()
                {
                    Id = new Guid(),
                    Name = "Test Tag 1"
                },
                new Tag()
                {
                    Id = new Guid(),
                    Name = "Test Tag 1"
                },
                new Tag()
                {
                    Id = new Guid(),
                    Name = "Test Tag 1"
                },
            };

            var serviceMock = new Mock<IAutocompleteService>(); // Using Moq to mock the service
            serviceMock
                .Setup(s => s.GetAllTags())
                .Returns(tagNamesVm);

            var controller = new AutocompleteController(serviceMock.Object);

            // Act
            var response = controller.GetTags();

            // Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
