namespace MIBI.Data.Interfaces
{
    using MIBI.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IMIBIContext
    {
        DbSet<Sample> Samples { get; set; }  

        DbSet<Group> Groups { get; set; }

        DbSet<SampleImage> Images { get; set; }

        DbSet<Tag> Tags { get; set; }

        DbSet<SampleGroup> SampleGroups { get; set; }

        DbSet<SampleTag> SampleTags { get; set; }

        DbSet<NutrientAgarPlate> NutrientAgarPlates { get; set; }

        int SaveChanges();
    }
}
