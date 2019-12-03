namespace MIBI.Services.Services
{
    using System.Linq;
    using AutoMapper;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using MIBI.Data.Interfaces;
    using MIBI.Services.Interfaces;
    using MIBI.Models.ViewModels.AutocompleateSuggestions;

    public class FilterService : Service, IAutocompleteService
    {
        private readonly IMapper mapper;

        public FilterService(IMIBIContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public List<GroupViewModel> GetAllGroups()
        {
            var groups = this.Context
                .Groups
                .AsNoTracking()
                .Select(g => new GroupViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();

            //return this.mapper.Map<List<GroupViewModel>>(groups);

            return groups;
        }

        public List<AutocompleteBacteriaNamesViewModel> GetAllNamesOfSamples()
        {
            var samples = this.Context
                .Samples
                .AsNoTracking()
                .Select(a => new AutocompleteBacteriaNamesViewModel {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();

            //return this.mapper.Map<List<AutocompleteBacteriaNamesViewModel>>(samples);

            return samples;
        }

        public List<TagViewModel> GetAllTags()
        {
            var tags = this.Context
                .Tags
                .AsNoTracking()
                .Select(t => new TagViewModel {
                    Id = t.Id,
                    Name = t.Name,
                    IconUrl = t.IconUrl,
                    Category = t.Category,
                    Color = t.Color
                })
                .ToList();

            //return this.mapper.Map<List<TagViewModel>>(tags);

            return tags;
        }

        public List<NutrientAgarPlateViewModel> GetAllNutrientAgarPlates()
        {
            var nutrientAgarPlates = this.Context
                .NutrientAgarPlates
                .AsNoTracking()
                .Select(n => new NutrientAgarPlateViewModel {
                    Id = n.Id,
                    Name = n.Name
                })
                .ToList();

            //return this.mapper.Map<List<NutrientAgarPlateViewModel>>(nutrientAgarPlates);

            return nutrientAgarPlates;
        }
    }
}
