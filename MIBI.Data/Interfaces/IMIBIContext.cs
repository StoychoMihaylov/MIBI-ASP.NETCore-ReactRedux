namespace MIBI.Data.Interfaces
{
    using MIBI.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IMIBIContext
    {
        DbSet<Sample> Samples { get; set; }

        int SaveChanges();
    }
}
