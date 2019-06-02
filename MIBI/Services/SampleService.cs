namespace MIBI.Services
{
    using MIBI.Data.Interfaces;
    using MIBI.Services.Interfaces;

    public class SampleService : Service, ISamleService
    {
        public SampleService(IMIBIContext context)
            : base(context) { }


    }
}
