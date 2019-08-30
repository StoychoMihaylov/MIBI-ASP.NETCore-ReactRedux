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

        public List<AutocompleteBacteriaNamesViewModel> GetAllNamesOfSamples(string bacteriaName)
        {
            //if (bacteriaName != null || bacteriaName != "")
            //{
            //    return this.Context.Samples.Where(b => b.Name.Contains(bacteriaName)).ToList();
            //}

            return null;
        }
    }
}
