namespace MIBI.Services.Interfaces
{
    using MIBI.Models.BindingModels;

    public interface ISampleService
    {
        void CreateNewSample(NewSampleBidingModel newSample);
    }
}
