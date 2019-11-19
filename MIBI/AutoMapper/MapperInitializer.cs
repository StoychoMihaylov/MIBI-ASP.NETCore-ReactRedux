namespace MIBI.AutoMapper
{
    using System;
    using System.Linq;
    using global::AutoMapper;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MIBI.Data.Entities;
    using MIBI.Models.ViewModels;
    using MIBI.Models.ViewModels.Sample;
    using MIBI.Models.ViewModels.AutocompleateSuggestions;

    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Sample, SampleViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<Group, GroupViewModel>().ReverseMap();
            CreateMap<NutrientAgarPlate, NutrientAgarPlateViewModel>().ReverseMap();
            CreateMap<Sample, AutocompleteBacteriaNamesViewModel>();
        }
    }
}
