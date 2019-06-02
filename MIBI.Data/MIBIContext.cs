namespace MIBI.Data
{
    using MIBI.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class MIBIContext : DbContext
    {
        public MIBIContext(DbContextOptions<MIBIContext> options)
            : base(options) { }

        DbSet<Sample> Samples { get; set; }

        DbSet<SampleImage> SampleImages { get; set; }

        DbSet<Tag> Tags { get; set; }
    }
}
