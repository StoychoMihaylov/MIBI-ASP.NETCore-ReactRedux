namespace MIBI.Data.Entities
{
    using System;

    public class SampleGroup
    {
        public Guid SampleId { get; set; }
        public Guid GroupId { get; set; }

        public Sample Sample { get; set; }
        public Group Group { get; set; }
    }
}
