﻿namespace MIBI.Models.ViewModels.Sample
{
    using System;
    using MIBI.Data.Entities;
    using System.Collections.Generic;

    public class SampleViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SampleImage> Images { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
