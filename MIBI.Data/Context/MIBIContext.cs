namespace MIBI.Data.Context
{
    using MIBI.Data.Entities;
    using MIBI.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class MIBIContext : DbContext, IMIBIContext
    {
        public MIBIContext(DbContextOptions<MIBIContext> options)
            : base(options){}

        public DbSet<Sample> Samples { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<SampleImage> Images { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
