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

        public DbSet<SampleGroup> SampleGroups { get; set; }

        public DbSet<SampleTag> SampleTags { get; set; }

        public DbSet<NutrientAgarPlate> NutrientAgarPlates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SampleGroup join tabl
            modelBuilder.Entity<SampleGroup>()
                .HasKey(sg => new { sg.SampleId, sg.GroupId });

            modelBuilder.Entity<SampleGroup>()
              .HasOne<Sample>(s => s.Sample)
              .WithMany(s => s.SampleGroups)
              .HasForeignKey(sc => sc.SampleId);

            // SampleTag join table
            modelBuilder
                .Entity<SampleTag>()
                .HasKey(st => new { st.SampleId, st.TagId });

            modelBuilder.Entity<SampleTag>()
                .HasOne<Tag>(st => st.Tag)
                .WithMany(st => st.SampleTags)
                .HasForeignKey(st => st.TagId);

            // SampleNutrientAgarPlateId join table
            modelBuilder.Entity<SampleNutrientAgarPlate>()
                .HasKey(sn => new { sn.SampleId, sn.NutrientAgarPlateId });

            modelBuilder.Entity<SampleNutrientAgarPlate>()
                .HasOne<Sample>(s => s.Sample)
                .WithMany(s => s.SampleNutrientAgarPlates)
                .HasForeignKey(sn => sn.SampleId);
        }
    }
}
