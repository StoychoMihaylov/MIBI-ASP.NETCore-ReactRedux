namespace MIBI.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Sample
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public virtual ICollection<SampleImage> ImgURLs { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
