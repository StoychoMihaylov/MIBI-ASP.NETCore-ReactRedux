namespace MIBI.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Sample
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public ICollection<SampleImage> Images { get; set; }

        public ICollection<SampleTag> SampleTags { get; set; }

        public ICollection<SampleGroup> SampleGroups { get; set; }

        public ICollection<SampleNutrientAgarPlate> SampleNutrientAgarPlates { get; set; }
    }
}
