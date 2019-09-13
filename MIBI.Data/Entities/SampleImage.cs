namespace MIBI.Data.Entities
{
    using System;

    public class SampleImage
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public Sample Sample { get; set; }
    }
}
