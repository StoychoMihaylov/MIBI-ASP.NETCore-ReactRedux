namespace MIBI.Services.Interfaces
{
    using System.Collections.Generic;
    using MIBI.Data.Entities;
    using MIBI.Models.BindingModels;
    using MIBI.Models.ViewModels;

    public interface ISampleService
    {
        void CreateNewSample(NewSampleBidingModel newSample);
        List<AutocompleteBacteriaNamesViewModel> GetAllNamesOfSamples();
        List<Tag> GetAllTags();
        List<GroupViewModel> GetAllGroups();
        List<NutrientAgarPlateViewModel> GetAllNutrientAgarPlates();
        List<SampleViewModel> GetAllSamplesByGivenSearchParams(SearchParametersBindingModel searchParams);
    }
}
