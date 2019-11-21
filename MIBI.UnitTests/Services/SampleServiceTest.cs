namespace MIBI.UnitTests.Services
{
    using Xunit;
    using System.Linq;
    using MIBI.Models.BindingModels.Sample;
    using MIBI.Services.Services;
    using MIBI.Data.Entities;
    using System.Collections.Generic;
    using MIBI.Models.ViewModels.Sample;

    public class SampleServiceTest : TestsInitializer
    {
        [Fact]
        public void CreateNewSample_CalledWithRelevantData_ShouldCreateSample()
        {
            // Arrange
            var db = this.GetDatabase();

            var newSampleData = new NewSampleBidingModel()
            {
                Name = "New Sample",
                Description = "Test Test Test",
                Tags = "tag1",
                Groups = "group1",
                NutrientAgarPlates = "nutrient1",
                ImgUrls = new List<string>()
                {
                    "some-image.jpg",
                    "another-image.jpg",
                    "test-image.jpg"
                }
            };

            var tag1 = new Tag() { Name = "tag1" };
            var group = new Group() { Name = "group1" };
            var nutrint = new NutrientAgarPlate() { Name = "nutrient1" };

            db.Tags.AddRange(tag1);
            db.Groups.Add(group);
            db.NutrientAgarPlates.Add(nutrint);
            db.SaveChanges();

            var service = new SampleService(db, null);

            // Act
            service.CreateNewSample(newSampleData);
            var cretedNewSample = db.Samples.First();

            // Assert
            Assert.NotNull(cretedNewSample);
            Assert.IsType<Sample>(cretedNewSample);
            var sampleName = cretedNewSample.Name;
            Assert.Equal("New Sample", sampleName);
        }

        [Fact]
        public void GetAllSamplesByGivenSearchParams_FilteredBacteriaName_ShouldReturnRelevantSample()
        {
            // Arrange
            var db = this.GetDatabase();
            var mapper = this.GetAutoMapper();

            var searchParams = new SearchParametersBindingModel()
            {
                BacteriaName = "New Sample"
            };

            var samples = new Sample()
            {
                Name = "New Sample"
            };

            db.Samples.Add(samples);
            db.SaveChanges();

            var service = new SampleService(db, mapper);

            // Act
            var result = service.GetAllSamplesByGivenSearchParams(searchParams);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<SampleViewModel>>(result);
            var sampleName = result[0].Name;
            Assert.Equal("New Sample", sampleName);
        }

        [Fact]
        public void GetAllSamplesByGivenSearchParams_FilteredByBacteriaNameAndGroup_ShouldReturnRelevantSamples()
        {
            // Arrange
            var db = this.GetDatabase();
            var mapper = this.GetAutoMapper();

            var searchParams = new SearchParametersBindingModel()
            {
                BacteriaName = "New Sample"
            };

            var sample = new Sample() { Name = "New Sample" };
            var group = new Group() { Name = "group1" };

            var sampleGroup = new SampleGroup()
            {
                Sample = sample,
                Group = group,
            };

            db.Samples.Add(sample);
            db.Groups.Add(group);
            db.SampleGroups.Add(sampleGroup);
            db.SaveChanges();

            var service = new SampleService(db, mapper);

            // Act
            var result = service.GetAllSamplesByGivenSearchParams(searchParams);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<SampleViewModel>>(result);
            var sampleName = result[0].Name;
            Assert.Equal("New Sample", sampleName);
        }
    }
}
