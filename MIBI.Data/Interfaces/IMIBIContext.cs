namespace MIBI.Data.Interfaces
{
    using MIBI.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IMIBIContext
    {
        DbSet<Sample> Samples { get; set; }

        DbSet<SampleImage> SampleImages { get; set; }

        DbSet<Tag> Tags { get; set; }

        int SaveChanges();
    }
}
