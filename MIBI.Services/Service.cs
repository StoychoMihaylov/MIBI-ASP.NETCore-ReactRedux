namespace MIBI.Services
{
    using AutoMapper;
    using MIBI.Data.Interfaces;

    public class Service
    {
        public Service(IMIBIContext context)
        {
            this.Context = context;
        }

        protected IMIBIContext Context { get; set; }
    }
}
