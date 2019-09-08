namespace MIBI.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<SampleTag> SampleTags { get; set; }
    }
}
