namespace MIBI.Models.ViewModels.Sample
{
    using System;
    using System.Collections.Generic;
    using MIBI.Data.Entities;

    public class DetailedSampleViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public ICollection<SampleImage> Images { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Group> Groups { get; set; }

        public ICollection<NutrientAgarPlate> NutrientAgarPlates { get; set; }
    }
}
