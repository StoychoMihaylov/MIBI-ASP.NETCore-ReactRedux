namespace MIBI.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SampleImage
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        [ForeignKey("SampleId")]
        public Sample Sample { get; set; }

        public Guid SampleId { get; set; }
    }
}
