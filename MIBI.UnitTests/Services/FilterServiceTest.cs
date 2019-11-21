namespace MIBI.UnitTests.Services
{
    using Xunit;
    using System.Linq;
    using MIBI.Data.Entities;
    using System.Collections.Generic;
    using MIBI.Services.Services;
    using MIBI.Models.ViewModels.AutocompleateSuggestions;

    public class FilterServiceTest : TestsInitializer
    {
        [Fact]
        public void GetAllGroups_CalledWithRelevantData_ShouldReturnListOfGroups()
        {
            // Arrange
            var db = this.GetDatabase();

            List<Group> dbGroups = new List<Group>()
            {
                new Group()
                {
                    Name = "Group 1"
                },
                new Group()
                {
                    Name = "Group 2"
                },
                new Group()
                {
                    Name = "Group 3"
                },
            };

            db.Groups.AddRange(dbGroups);
            db.SaveChanges();

            var mapper = this.GetAutoMapper();

            var service = new FilterService(db, mapper);

            // Act
            var groups = service.GetAllGroups();

            // Assert
            Assert.NotNull(groups);
            Assert.IsType<List<GroupViewModel>>(groups);
            Assert.Equal(3, groups.Count());
            Assert.Equal("Group 1", groups[0].Name);
        }

        [Fact]
        public void GetAllNamesOfSamples_CalledWithRelevantData_ShouldReturnListOfSampleNames()
        {
            // Arrange
            var db = this.GetDatabase();

            List<Sample> dbSamples = new List<Sample>()
            {
                new Sample()
                {
                    Name = "Sample 1"
                },
                new Sample()
                {
                    Name = "Sample 2"
                },
                new Sample()
                {
                    Name = "Sample 3"
                },
            };

            db.Samples.AddRange(dbSamples);
            db.SaveChanges();

            var mapper = this.GetAutoMapper();

            var service = new FilterService(db, mapper);

            // Act
            var groups = service.GetAllNamesOfSamples();

            // Assert
            Assert.NotNull(groups);
            Assert.IsType<List<AutocompleteBacteriaNamesViewModel>>(groups);
            Assert.Equal(3, groups.Count());
            Assert.Equal("Sample 1", groups[0].Name);
        }

        [Fact]
        public void GetAllNutrientAgarPlates_CalledWithRelevantData_ShouldReturnListOfNutrientAgarPlates()
        {
            // Arrange
            var db = this.GetDatabase();

            List<NutrientAgarPlate> dbNutrientAgarPlates = new List<NutrientAgarPlate>()
            {
                new NutrientAgarPlate()
                {
                    Name = "NutrientAgarPlate 1"
                },
                new NutrientAgarPlate()
                {
                    Name = "NutrientAgarPlate 2"
                },
                new NutrientAgarPlate()
                {
                    Name = "NutrientAgarPlate 3"
                },
            };

            db.NutrientAgarPlates.AddRange(dbNutrientAgarPlates);
            db.SaveChanges();

            var mapper = this.GetAutoMapper();

            var service = new FilterService(db, mapper);

            // Act
            var groups = service.GetAllNutrientAgarPlates();

            // Assert
            Assert.NotNull(groups);
            Assert.IsType<List<NutrientAgarPlateViewModel>>(groups);
            Assert.Equal(3, groups.Count());
            Assert.Equal("NutrientAgarPlate 1", groups[0].Name);
        }

        [Fact]
        public void GetAllTags_CalledWithRelevantData_ShouldReturnListOfGetTags()
        {
            // Arrange
            var db = this.GetDatabase();

            List<Tag> dbTag = new List<Tag>()
            {
                new Tag()
                {
                    Name = "Tag 1"
                },
                new Tag()
                {
                    Name = "Tag 2"
                },
                new Tag()
                {
                    Name = "Tag 3"
                },
            };

            db.Tags.AddRange(dbTag);
            db.SaveChanges();

            var mapper = this.GetAutoMapper();

            var service = new FilterService(db, mapper);

            // Act
            var groups = service.GetAllTags();

            // Assert
            Assert.NotNull(groups);
            Assert.IsType<List<TagViewModel>>(groups);
            Assert.Equal(3, groups.Count());
            Assert.Equal("Tag 1", groups[0].Name);
        }
    }
}
