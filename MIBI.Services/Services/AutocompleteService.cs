namespace MIBI.Services.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using MIBI.Data.Entities;
    using MIBI.Data.Interfaces;
    using MIBI.Services.Interfaces;
    using MIBI.Models.ViewModels.AutocompleateSuggestions;

    public class AutocompleteService : Service, IAutocompleteService
    {
        public AutocompleteService(IMIBIContext context)
            : base(context)
        {
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
