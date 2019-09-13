namespace MIBI.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class NutrientAgarPlate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<SampleNutrientAgarPlate> SampleNutrientAgarPlates { get; set; }
    }
}
