namespace MIBI.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Group
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<SampleGroup> SampleGroups { get; set; }
    }
}
