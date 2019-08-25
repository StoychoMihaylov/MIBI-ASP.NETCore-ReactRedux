namespace MIBI.Services.Services
{
    using MIBI.Data.Interfaces;
    using MIBI.Models.BindingModels;
    using MIBI.Services.Interfaces;

    public class SampleService : Service, ISampleService
    {
        public SampleService(IMIBIContext context)
            : base(context) { }

        public void CreateNewSample(NewSampleBidingModel newSample)
        {

        }
    }
}
