namespace MIBI.Services.Interfaces
{
    using System.Collections.Generic;
    using MIBI.Models.ViewModels.Sample;
    using MIBI.Models.BindingModels.Sample;
    using MIBI.Data.Entities;

    public interface ISampleService
    {
        void CreateNewSample(NewSampleBidingModel newSample);
        List<SampleViewModel> GetAllSamplesByGivenSearchParams(SearchParametersBindingModel searchParams);
        Sample GetSampleById(string id);
    }
}
