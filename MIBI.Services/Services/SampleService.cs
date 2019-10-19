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
    using Microsoft.EntityFrameworkCore;

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
            List<SampleNutrientAgarPlate> sampleNutrientAgarPlates = 
                CreateNewSampleNutrientAgarPlatesByNutrientAgarPlates(newSampleData.NutrientAgarPlates.Split(','));

            Sample newSample = new Sample()
            {
                Name = newSampleData.Name,
                Description = newSampleData.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = "Bai Pesho",
                SampleGroups = sampleGroups,
                SampleTags = sampleTags,
                SampleNutrientAgarPlates = sampleNutrientAgarPlates,
                Images = newImgs
            };

            this.Context.Samples.Add(newSample);
            this.Context.SaveChanges();
        }

        private List<SampleNutrientAgarPlate> CreateNewSampleNutrientAgarPlatesByNutrientAgarPlates(string[] newNutrientAgarPlates)
        {
            var nutrientAgarPlates = new List<SampleNutrientAgarPlate>();

            foreach (var name in newNutrientAgarPlates)
            {
                SampleNutrientAgarPlate newNutrient = new SampleNutrientAgarPlate()
                {
                    NutrientAgarPlate = this.Context.NutrientAgarPlates.Where(t => t.Name == name).First()
                };

                nutrientAgarPlates.Add(newNutrient);
            }

            return nutrientAgarPlates;
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

        public List<SampleViewModel> GetAllSamplesByGivenSearchParams(SearchParametersBindingModel searchParams)
        {
            var foundSamples = FindSampleDependingOnGivenParams(searchParams);

            var sampleViewModels = this.mapper.Map<List<SampleViewModel>>(foundSamples);

            return sampleViewModels;
        }

        private List<Sample> FindSampleDependingOnGivenParams(SearchParametersBindingModel searchParams)
        {
            var samples = new List<Sample>();

            // Searching by given name
            if (searchParams.Tags == null &&
               searchParams.Groups == null &&
               searchParams.BacteriaName != null &&
               searchParams.NutrientAgarPlates == null)
            {
                samples = this.Context
                    .Samples
                    .Include(s => s.Images)
                    .Where(sample => sample.Name.Contains(searchParams.BacteriaName))
                    .ToList();

            } // Searching by Name plus any other provided search params
            else if (searchParams.BacteriaName != null && 
                (searchParams.Tags != null || searchParams.Groups != null || searchParams.NutrientAgarPlates != null))
            {
                var samplesFromDB = this.Context
                    .Samples
                    .Include(s => s.Images)
                    .Include(s => s.SampleTags)
                        .ThenInclude(st => st.Tag)
                    .Include(s => s.SampleGroups)
                        .ThenInclude(sg => sg.Group)
                    .Include(s => s.SampleNutrientAgarPlates)
                        .ThenInclude(sn => sn.NutrientAgarPlate)
                    .Where(sample => sample.Name.Contains(searchParams.BacteriaName))
                    .ToList();

                // Filtering the samples containing certan name by any other given search param
                foreach (var sample in samplesFromDB)
                {
                    var IsMatch = true;

                    if (searchParams.Tags != null)
                    {
                        foreach (var sampleTag in sample.SampleTags)
                        {
                            if (!searchParams.Tags.Contains(sampleTag.Tag.Name))
                            {
                                IsMatch = false;
                                break;
                            }
                        }
                    }

                    if (searchParams.Groups != null)
                    {
                        foreach (var sampleGroup in sample.SampleGroups)
                        {
                            if (! searchParams.Groups.Contains(sampleGroup.Group.Name))
                            {
                                IsMatch = false;
                                break;
                            }
                        }
                    }

                    if (searchParams.NutrientAgarPlates != null)
                    {
                        foreach (var sampleNutrient in sample.SampleNutrientAgarPlates)
                        {
                            if (! searchParams.NutrientAgarPlates.Contains(sampleNutrient.NutrientAgarPlate.Name))
                            {
                                IsMatch = false;
                                break;
                            }
                        }
                    }

                    if (IsMatch)
                    {
                        samples.Add(sample);
                    }
                }       
            }

            // Stoping reference loop
            foreach (var sample in samples)
            {
                foreach (var img in sample.Images)
                {
                    img.Sample = null;
                }
            }

            return samples;
        }

        public Sample GetSampleById(string id)
        {
            var sample = this.Context.Samples
                .Include(s => s.Images)
                .Include(s => s.SampleTags)
                    .ThenInclude(st => st.Tag)
                .Include(s => s.SampleGroups)
                    .ThenInclude(sg => sg.Group)
                .Include(s => s.SampleNutrientAgarPlates)
                    .ThenInclude(sn => sn.NutrientAgarPlate)
                .Where(s => s.Id == new Guid(id))
                .First();


            // Delete thr reference loop
            foreach (var img in sample.Images)
            {
                img.Sample = null;
            }
            foreach (var sg in sample.SampleGroups)
            {
                sg.Group.SampleGroups = null;
                sg.Sample = null;
            }
            foreach (var st in sample.SampleTags)
            {
                st.Tag.SampleTags = null;
                st.Sample = null;
            }
            foreach (var sn in sample.SampleNutrientAgarPlates)
            {
                sn.NutrientAgarPlate.SampleNutrientAgarPlates = null;
                sn.Sample = null;
            }

            return sample;
        }
    }
}
