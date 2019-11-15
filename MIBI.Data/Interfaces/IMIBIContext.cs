namespace MIBI.Data.Interfaces
{
    using MIBI.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IMIBIContext
    {
        DbSet<User> Users { get; set; }

        DbSet<TokenManager> Tokens { get; set; }

        DbSet<Sample> Samples { get; set; }  

        DbSet<Group> Groups { get; set; }

        DbSet<SampleImage> Images { get; set; }

        DbSet<Tag> Tags { get; set; }

        DbSet<SampleGroup> SampleGroups { get; set; }

        DbSet<SampleTag> SampleTags { get; set; }

        DbSet<NutrientAgarPlate> NutrientAgarPlates { get; set; }

        DbSet<SampleNutrientAgarPlate> SampleNutrientAgarPlates { get; set; }

        int SaveChanges();
    }
}
