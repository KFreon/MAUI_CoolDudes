using MAUI_CoolDudes.Database;
using Microsoft.EntityFrameworkCore;

public class CoolDudeDbContext : DbContext
{
    public CoolDudeDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CoolDude>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<CoolDude>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }

    public DbSet<CoolDude> CoolDudes { get; set; }
}

