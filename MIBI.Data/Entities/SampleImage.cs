namespace MIBI.Data.Entities
{
    using System;

    public class SampleImage
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UploadedBy { get; set; }

        public virtual Sample Sample { get; set; }
    }
}
