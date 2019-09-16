namespace MIBI.Services.Services
{
    using System;
    using MIBI.Data.Entities;
    using MIBI.Data.Interfaces;
    using MIBI.Models.BindingModels;
    using MIBI.Services.Interfaces;
    using System.Collections.Generic;
    using MIBI.Models.ViewModels;
    using System.Linq;
    using AutoMapper;

    public class SampleService : Service, ISampleService
    {
        private readonly IMapper mapper;
        public SampleService(IMIBIContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public void CreateNewSample(NewSampleBidingModel newSampleData)
        {
            List<SampleGroup> sampleGroups = CrateSampleGroupsByGroupName(newSampleData.Groups.Split(','));
            List<SampleTag> sampleTags = CreateSampleTagsByTagName(newSampleData.Tags.Split(','));
            List<SampleImage> newImgs = CreateNewImagesByGivenUrls(newSampleData.ImgUrls);

            Sample newSample = new Sample()
            {
                Name = newSampleData.Name,
                Description = newSampleData.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = "Bai Pesho",
                SampleGroups = sampleGroups,
                SampleTags = sampleTags,
                ImgURLs = newImgs
            };   

            this.Context.Samples.Add(newSample);
            this.Context.SaveChanges();
        }

        private List<SampleImage> CreateNewImagesByGivenUrls(List<string> imgUrls)
        {
            var imgs = new List<SampleImage>();

            foreach (var url in imgUrls)
            {
                SampleImage newImg = new SampleImage()
                {
                    Url = url
                };

                imgs.Add(newImg);
            }

            return imgs;
        }

        private List<SampleTag> CreateSampleTagsByTagName(string[] tags)
        {
            var sampleTags = new List<SampleTag>();

            foreach (var name in tags)
            {
                var sampleTag = new SampleTag()
                {
                    Tag = this.Context.Tags.Where(t => t.Name == name).First()
                };

                sampleTags.Add(sampleTag);
            }

            return sampleTags;
        }

        private List<SampleGroup> CrateSampleGroupsByGroupName(string[] groups)
        {
            var sampleGroups = new List<SampleGroup>();

            foreach (var name in groups)
            {
                var sampleGroup = new SampleGroup()
                {
                    Group = this.Context.Groups.Where(g => g.Name == name).First()
                };

                sampleGroups.Add(sampleGroup);
            }

            return sampleGroups;
        }

        public List<GroupViewModel> GetAllGroups()
        {
            var groupsVm = new List<GroupViewModel>();

            var groups = this.Context
                .Groups
                .Select(g => new { g.Id, g.Name })
                .ToList();

            foreach (var group in groups)
            {
                var groupName = new GroupViewModel()
                {
                    Id = group.Id,
                    Name = group.Name
                };

                groupsVm.Add(groupName);
            }

            return groupsVm;
        }

        public List<AutocompleteBacteriaNamesViewModel> GetAllNamesOfSamples()
        {
            var namesOfSamples = new List<AutocompleteBacteriaNamesViewModel>();

            var samples = this.Context
                .Samples
                .Select(b => new { b.Id, b.Name })
                .ToList();

            foreach (var sample in samples)
            {
                var sampleName = new AutocompleteBacteriaNamesViewModel()
                {
                    Id = sample.Id, 
                    Name = sample.Name
                };

                namesOfSamples.Add(sampleName);
            }
            
            return namesOfSamples;
        }

        public List<Tag> GetAllTags()
        {
            var tags = this.Context
                .Tags
                .ToList();

            return tags;
        }

        public List<NutrientAgarPlateViewModel> GetAllNutrientAgarPlates()
        {
            var result = new List<NutrientAgarPlateViewModel>();

            var nutrientAgarPlates = this.Context
                .NutrientAgarPlates
                .ToList();

            foreach (var nut in nutrientAgarPlates)
            {
                var newNut = new NutrientAgarPlateViewModel()
                {
                    Id = nut.Id,
                    Name = nut.Name
                };

                result.Add(newNut);
            }

            return result;
        }
    }
}
