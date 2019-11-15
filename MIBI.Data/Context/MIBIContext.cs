namespace MIBI.Data.Context
{
    using MIBI.Data.Entities;
    using MIBI.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class MIBIContext : DbContext, IMIBIContext
    {
        public MIBIContext(DbContextOptions<MIBIContext> options)
            : base(options){}

        public DbSet<User> Users { get; set; }

        public DbSet<TokenManager> Tokens { get; set; }

        public DbSet<Sample> Samples { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<SampleImage> Images { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<SampleGroup> SampleGroups { get; set; }

        public DbSet<SampleTag> SampleTags { get; set; }

        public DbSet<NutrientAgarPlate> NutrientAgarPlates { get; set; }

        public DbSet<SampleNutrientAgarPlate> SampleNutrientAgarPlates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SampleGroup join table
            modelBuilder.Entity<SampleGroup>()
                .HasKey(sg => new { sg.SampleId, sg.GroupId });

            modelBuilder.Entity<SampleGroup>()
              .HasOne(s => s.Sample)
              .WithMany(s => s.SampleGroups)
              .HasForeignKey(sc => sc.SampleId);

            modelBuilder.Entity<SampleGroup>()
                .HasOne(g => g.Group)
                .WithMany(g => g.SampleGroups)
                .HasForeignKey(g => g.GroupId);

            //SampleTag join table
            modelBuilder.Entity<SampleTag>()
                .HasKey(st => new { st.SampleId, st.TagId });

            modelBuilder.Entity<SampleTag>()
             .HasOne(s => s.Sample)
             .WithMany(s => s.SampleTags)
             .HasForeignKey(sc => sc.SampleId);

            modelBuilder.Entity<SampleTag>()
                .HasOne(t => t.Tag)
                .WithMany(t => t.SampleTags)
                .HasForeignKey(t => t.TagId);

            // SampleNutrientAgarPlateId join table
            modelBuilder.Entity<SampleNutrientAgarPlate>()
                .HasKey(sn => new { sn.SampleId, sn.NutrientAgarPlateId });

            modelBuilder.Entity<SampleNutrientAgarPlate>()
                .HasOne(s => s.Sample)
                .WithMany(s => s.SampleNutrientAgarPlates)
                .HasForeignKey(sn => sn.SampleId);

            modelBuilder.Entity<SampleNutrientAgarPlate>()
                .HasOne(n => n.NutrientAgarPlate)
                .WithMany(n => n.SampleNutrientAgarPlates)
                .HasForeignKey(n => n.NutrientAgarPlateId);
        }
    }
}
