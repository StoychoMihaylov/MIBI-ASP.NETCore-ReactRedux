namespace MIBI.AutoMapper
{
    using global::AutoMapper;
    using MIBI.Data.Entities;
    using MIBI.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Sample, SampleViewModel>().ReverseMap();
        }
    }
}
