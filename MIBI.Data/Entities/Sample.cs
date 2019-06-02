namespace MIBI.Data.Entities
{
    using System.Collections.Generic;

    public class Sample
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<SampleImage> Images { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
