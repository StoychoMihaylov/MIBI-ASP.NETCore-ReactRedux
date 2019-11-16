namespace MIBI.Services.Interfaces
{
    using System.Collections.Generic;
    using MIBI.Data.Entities;
    using MIBI.Models.ViewModels.Sample;
    using MIBI.Models.BindingModels.Sample;

    public interface ISampleService
    {
        void CreateNewSample(NewSampleBidingModel newSample);
        List<SampleViewModel> GetAllSamplesByGivenSearchParams(SearchParametersBindingModel searchParams);
        Sample GetSampleById(string id);
    }
}
