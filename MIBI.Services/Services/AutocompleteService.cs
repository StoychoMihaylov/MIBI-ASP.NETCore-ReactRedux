namespace MIBI.Services.Services
{
    using System.Linq;
    using AutoMapper;
    using System.Collections.Generic;
    using MIBI.Data.Interfaces;
    using MIBI.Services.Interfaces;
    using MIBI.Models.ViewModels.AutocompleateSuggestions;

    public class AutocompleteService : Service, IAutocompleteService
    {
        private readonly IMapper mapper;

        public AutocompleteService(IMIBIContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public List<GroupViewModel> GetAllGroups()
        {
            var groups = this.Context
                .Groups
                .ToList();

            return this.mapper.Map<List<GroupViewModel>>(groups);
        }

        public List<AutocompleteBacteriaNamesViewModel> GetAllNamesOfSamples()
        {
            var samples = this.Context
                .Samples
                .ToList();

            return this.mapper.Map<List<AutocompleteBacteriaNamesViewModel>>(samples);
        }

        public List<TagViewModel> GetAllTags()
        {
            var tags = this.Context
                .Tags
                .ToList();

            return this.mapper.Map<List<TagViewModel>>(tags);
        }

        public List<NutrientAgarPlateViewModel> GetAllNutrientAgarPlates()
        {
            var nutrientAgarPlates = this.Context
                .NutrientAgarPlates
                .ToList();

            return this.mapper.Map<List<NutrientAgarPlateViewModel>>(nutrientAgarPlates);
        }
    }
}
