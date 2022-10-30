using Microsoft.EntityFrameworkCore;

namespace LiveSync.Client;

public class ApplicationDbContext:DbContext
{
    public DbSet<ClinicalVisit> Visits { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClinicalVisit>()
            .ToTable("stg_PatientVisits")
            .HasKey(c => new { c.PatientPK, c.SiteCode });
        
        base.OnModelCreating(modelBuilder);
    }
}
