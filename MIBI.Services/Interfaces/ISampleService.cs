namespace MIBI.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MIBI.Data.Entities;
    using MIBI.Models.ViewModels.Sample;
    using MIBI.Models.BindingModels.Sample;

    public interface ISampleService
    {
        void CreateNewSample(NewSampleBidingModel newSample, User currentUser);
        List<SampleViewModel> GetAllSamplesByGivenSearchParams(SearchParametersBindingModel searchParams);
        Task<DetailedSampleViewModel> GetSampleById(string id);
    }
}
