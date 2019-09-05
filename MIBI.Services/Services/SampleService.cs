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

    public class SampleService : Service, ISampleService
    {
        public SampleService(IMIBIContext context)
            : base(context) { }

        public void CreateNewSample(NewSampleBidingModel newSampleData)
        {
            List<Tag> newTags = new List<Tag>();
            foreach (var name in newSampleData.Tags)
            {
                Tag newTag = new Tag()
                {
                    Name = name
                };

                newTags.Add(newTag);
            }

            List<Group> newGroups = new List<Group>();
            foreach (var name in newSampleData.Groups)
            {
                Group newGroup = new Group()
                {
                    Name = name
                };

                newGroups.Add(newGroup);
            }

            List<SampleImage> newImgs = new List<SampleImage>();
            foreach (var url in newSampleData.ImgUrls)
            {
                SampleImage newImg = new SampleImage()
                {
                    Url = url
                };

                newImgs.Add(newImg);
            }

            Sample newSample = new Sample()
            {
                Name = newSampleData.Name,
                Description = newSampleData.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = "Bai Pesho",
                Groups = newGroups,
                Tags = newTags,
                ImgURLs = newImgs
            };

            this.Context.Samples.Add(newSample);
            this.Context.SaveChanges();
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

        public List<TagNameViewModel> GetAllTags()
        {
            var allTags = new List<TagNameViewModel>();

            var tags = this.Context
                .Tags
                .Select(b => new { b.Id, b.Name })
                .ToList();

            foreach (var tag in tags)
            {
                var sampleName = new TagNameViewModel()
                {
                    Id = tag.Id,
                    Name = tag.Name
                };

                allTags.Add(sampleName);
            }

            return allTags;
        }
    }
}
