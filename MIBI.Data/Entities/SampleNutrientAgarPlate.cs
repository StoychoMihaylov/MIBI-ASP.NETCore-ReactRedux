namespace MIBI.Data.Entities
{
    using System;

    public class SampleNutrientAgarPlate
    {
        public Guid SampleId { get; set; }
        public Sample Sample { get; set; }

        public Guid NutrientAgarPlateId { get; set; }
        public NutrientAgarPlate NutrientAgarPlate { get; set; }
    }
}
